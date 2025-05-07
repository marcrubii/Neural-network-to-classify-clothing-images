#include <stdio.h>
#include <string.h>
#include <stdlib.h> //Necesario para atof
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <unistd.h>
#include <ctype.h>
#include <mysql.h>
#include <pthread.h>

//Variables globales
	//Para la BBDD
MYSQL *conn;

	//Esctructura necesaria para acceso autoexcluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

	//Lista de conectados (formada por usuarios)
typedef struct{
	char nombre[25];
	int *socket;
}Usuario;

typedef struct{
	Usuario conectados[50];
	int num;
}ListaConectados;

	//Iniciamos la lista de conectados
ListaConectados listaC;

	//Para poder notificar a todos los clientes, necesitamos que el vector de sockets sea una variable global
int i;
int sockets[100];


//Funciones de nuestro servidor

//Iniciar sesión - codigo 1
int InicioSesion(char nombre[25], char password[20]){
	//Devuelve un 0 si todo va bien, un 1 si el user no se ha registrado, 2 si no coincide la contraseña y -1 si algo falla en la consulta.
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	char consulta[100];
	strcpy(consulta,"SELECT contrasenya FROM jugadores WHERE nombre='");
	strcat(consulta,nombre);
	strcat(consulta,"'");
	
	
	err=mysql_query(conn,consulta);
	if (err != 0){
		printf("Error al consultar la información en la base de datos %u %s",mysql_errno(conn),mysql_error(conn));
		return -1;
	}
	else{
		//Recibimos el resultado de la consulta
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		if (row == NULL)
			return 1;
		else
		{
			printf("%s\n",row[0]);
			if (strcmp(password,row[0])==0)
				return 0;
			else
				return 2;
			
		}
		
	}
}

//Registrarse - codigo 2
int Registro(char nombre[25], char password[20], char mail[100]){
	//Retorna un 0 si todo va bien, un 1 si ya existe ese usuario y un -1 si algo va mal en la consulta
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	//Busca si ya hay un usuario con ese nombre
	char consulta[100];
	strcpy(consulta, "SELECT nombre FROM jugadores WHERE nombre='");
	strcat(consulta, nombre);
	strcat(consulta, "'");
	
	err = mysql_query(conn, consulta);
	if (err!=0)
		return -1;
	
	else {
		resultado = mysql_store_result(conn);
		row =  mysql_fetch_row(resultado);
		
		//Se registra si no hay nadie con el mismo nombre
		if (row==NULL) {
			
			err=mysql_query(conn, "SELECT * FROM jugadores WHERE id=(SELECT max(id) FROM jugadores);");
			if (err!=0){
				return -1;
			}
			resultado = mysql_store_result(conn);
			row =  mysql_fetch_row(resultado);
			printf("%s\n",row[0]);
			int id = atoi(row[0])+1;
			sprintf(consulta,"INSERT INTO jugadores VALUES ('%d','%s','%s','%s');", id, nombre, password, mail);
			printf("%s\n",consulta);
			err= mysql_query(conn, consulta);
			if (err!=0)
				return -1;						
			else
				return 0; 
		}
		else
			return 1;  
		
	}
}

//Devuelve la contraseña de un usuario en concreto - codigo 3
int DamePassword(char nombre[25], char password[20]){
	//Devuelve un 0 y la contraseña si todo va bien, un 1 si no existe el usuario y un -1 si hay un error en la consulta
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	char consulta[80];
	strcpy(consulta,"SELECT contrasenya FROM jugadores WHERE nombre='");
	strcat(consulta,nombre);
	strcat(consulta,"'");
	
	err=mysql_query(conn,consulta);
	if (err!=0)
		return -1;
	else{
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		
		if (row == NULL){
			strcpy(password,"\0");
			return 1;
		}
		else{
			strcpy(password,row[0]);
			return 0;
		}
	}
}

//Devuelve la partida que más ha durado - codigo 4
int DamePartidaMasLarga(){
	//Devuelve el ID de partida de la tabla de relacion si todo va bien, un -1 si hay un error de consulta, y un -2 si no hay partidas en la base de datos
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	err=mysql_query (conn, "SELECT partidas.id FROM partidas WHERE partidas.duracion = (SELECT MAX(partidas.duracion) FROM partidas)");
	if (err!=0)
		return -1;
	else{
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		
		if (row == NULL)
			return -2;
		else{
			int idP = atoi(row[0]);
			return idP; 
		}
	}
}

//Devuelve el jugador más valuado (MVP) - codigo 5
int DameMVP(char nombre[25]){
	//Devuelve un 0 y el nombre del MVP si todo va bien, un -1 si hay un error en la conssulta y un -2 si no hay jugadores en la base de datos
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	err=mysql_query (conn, "SELECT jugadores.nombre FROM (jugadores, registro) WHERE registro.puntos=(SELECT MAX(registro.puntos) FROM registro) AND registro.idJ=jugadores.id");
	if (err!=0){
		strcpy(nombre,"\0");
		return -1;
	}
	else{
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		
		if (row == NULL){
			strcpy(nombre,"\0");
			return -2;
		}
		else{
			strcpy(nombre,row[0]); 
			return 0;
		}
	}
	
}
//Da la lista de conectados - codigo 6
int DameListaConectados(char lista[512]){
	//Devuelve un 0 y la lista de conectados si todo va bien y un -1 si la lista esta vacía
	
	strcpy(lista,"\0");
	if (listaC.num != 0){
		int i;
		for (i=0;i<listaC.num;i++)
			sprintf(lista,"%s%s*",lista,listaC.conectados[i].nombre);
		lista[strlen(lista)-1]='\0';
		return 0;
	}
	else
		return -1;
	
}
//Añadir a la lista de conectados
void AnadirAListaConectados (char nombre[25],int *socket){
	
	if (nombre != NULL && socket != NULL){
		//Creamos un nuevo usuario que añadir a la lista
		Usuario nuevoUsuario;
		strcpy(nuevoUsuario.nombre,nombre);
		nuevoUsuario.socket = socket;
		
		//Lo añadimos
		listaC.conectados[listaC.num]=nuevoUsuario;
		listaC.num = listaC.num+1;
	}	
}
//Retirar de la lista de conectados
void RetirarDeListaConectados (char nombre[25]) {
	
	if (nombre != NULL){
		int n = 0;
		int encontrado = 0;
		
		while(n<listaC.num && encontrado==0){
			if (strcmp(listaC.conectados[n].nombre,nombre)==0){
				encontrado = 1;
			}
			else
				n++;
		}
		if (encontrado==1){
			while(n<listaC.num){
				listaC.conectados[n]=listaC.conectados[n+1];
				n++;
			}
			listaC.num = listaC.num-1;
		}
	}
}
//Notificar actualizacion de la lista de conectados
void NotificarNuevaListaConectados(){
	
	char lista[512];
	char notificacion[512];
	
	//pthread_mutex_lock(&mutex);
	int res = DameListaConectados(lista);
	//pthread_mutex_unlock(&mutex);
	
	printf("Notificacion de actualizacion de ListaConectados\n");
	if (res == 0){
		printf("Lista de conectados con nuevos datos\n");
		sprintf(notificacion,"6/%s",lista);
	}
	else{
		printf("Lista de conectados vacia\n");
		sprintf(notificacion,"6/%s",lista);
	}
	
	//Envia actualización a todos los sockets
	int j;
	for (j=0;j<listaC.num;j++){
		write(listaC.conectados[j].socket,notificacion,strlen(notificacion));
	}
	
}
//Atencion a los diferentes clientes (threads)
int *AtenderCliente(void *socket){
	
	char peticion[512];
	char respuesta[512];
	
	int ret;
	int sock_conn;
	int *s;
	s = (int *) socket;
	sock_conn = *s;
	
	//Variable para saber si se tiene que desconectar
	int terminar = 0;
	while (terminar==0)
	{
		// Informacion recibida almacenada en la petición
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		printf("%s\n",peticion);
		
		// Tenemos que añadirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		//Escribimos en consola lo que nos ha llegado (petición)
		printf("Se ha conectado: %s\n",peticion);
		
		//Datos de un cliente
		char nombre[25];
		char password[20];
		char mail[100];
		
		//Obtenemos el codigo que nos indica el tipo de petición.
		char *p = strtok(peticion,"/");
		int codigo = atoi(p);
		printf("%d\n",codigo);
		
		
		//Codigo 0 --> Desconexión
		if (codigo == 0){
			//Mensaje en la peticion: 0/
			//Return en la respuesta: -
			terminar = 1;
			
			pthread_mutex_lock(&mutex);
			RetirarDeListaConectados(nombre);
			NotificarNuevaListaConectados();
			
			pthread_mutex_unlock(&mutex);
			
			
		}
		else {
			//Codigo 1 --> Inicio de sesión
			if (codigo == 1){
				//Mensaje en la peticion: 1/username/password
				//Return en la respuesta: 0 si todo va bien, un 1 si el user no se ha registrado, 2 si no coincide la contraseña y -1 si algo falla en la consulta.
				
				p = strtok(NULL,"/");
				strcpy(nombre,p);
				p = strtok(NULL,"/");
				strcpy(password,p);
				
				int res = InicioSesion(nombre,password);
				sprintf(respuesta,"1/%d", res);
				
				//Añadimos a la lista de conectados si todo ha ido bien
				if (res == 0){
					pthread_mutex_lock(&mutex);  //Autoexclusion
					AnadirAListaConectados(nombre,sock_conn);
					NotificarNuevaListaConectados();
					pthread_mutex_unlock(&mutex);
					
					
				}
				
			}
			
			//Codigo 2 --> Registro de nuevos jugadores
			else if (codigo==2){ 
				//Mensaje en la peticion: 2/username/password/mail
				//Return en la respuesta: un 0 si todo va bien, un 1 si ya existe ese usuario y un -1 si algo va mal en la consulta
				
				p = strtok(NULL, "/");
				strcpy(nombre, p);
				p = strtok (NULL, "/");
				strcpy (password, p);
				p = strtok(NULL,"/");
				strcpy(mail, p);
				
				int res = Registro(nombre,password,mail);
				sprintf(respuesta,"2/%d",res);
				
			}
			
			
			//Codigo 3 --> Devuelve la contraseña
			else if (codigo == 3){
				//Mensaje en la peticion: 3/usuario
				//Return en la respuesta: un 0 y la contraseña si todo va bien, un 1 si no existe el usuario y un -1 si hay un error en la consulta
				
				p = strtok(NULL,"/");
				strcpy(nombre,p);
				
				int res = DamePassword(nombre,password);
				if (res ==0)
					sprintf(respuesta,"3/%s",password);
				else
					sprintf(respuesta,"3/%d",res);
				
			}
			
			//Codigo 4 --> Devuelve la partida más longeva
			else if (codigo == 4){
				//Mensaje en la peticion: 4/
				//Return en la respuesta: un 0 y el nombre del MVP si todo va bien, un -1 si hay un error en la conssulta y un -2 si no hay jugadores en la base de datos
				
				int res = DamePartidaMasLarga();
				sprintf(respuesta,"4/%d",res);
				
			}
			
			//Codigo 5 --> Obtener jugador con más puntos
			else if (codigo==5){
				//Mensaje en la peticion: 5/
				//Return en la respuesta: un 0 y el nombre del MVP si todo va bien, un -1 si hay un error en la conssulta y un -2 si no hay jugadores en la base de datos
				
				int res = DameMVP(nombre);
				if (res == 0)
					sprintf(respuesta,"5/%s",nombre);
				else
					sprintf(respuesta,"5/%d",res);
				
			}
			// Y lo enviamos
			if (codigo!=0){
				write (sock_conn,respuesta, strlen(respuesta));
				printf("Codigo: %d , Resultado: %s\n",codigo,respuesta);
				// Resultado de la acción
			}
		}
		
	}
	
	// Se acabo el servicio para este cliente
	close(sock_conn);
	pthread_exit(0);
}


//Programa principal del servidor

int main(int argc, char *argv[]) {

	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	//Ponemos a 0 el numeros de conectados en la lista de conectados
	listaC.num=0;
	
	// Abrimos el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket\n");
	// Hacemos el bind al puerto
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 50051
	serv_adr.sin_port = htons(50055);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind\n");
	if (listen(sock_listen, 2) < 0)
		printf("Error en el Listen\n");
	
	//Creamos la connexión a la BBDD
	conn = mysql_init(NULL);
	if (conn == NULL){
		printf("Error al crear la connexión: %u %s\n",mysql_errno(conn),mysql_error(conn));
		exit(1);
	}
	
	conn = mysql_real_connect(conn,"localhost","root","mysql","T02_BBDD",0,NULL,0);
	if (conn==NULL){
		printf("Error al crear la connexión: %u %s\n",mysql_errno(conn),mysql_error(conn));
		exit(1);
	}
	
	pthread_t thread[100];
	pthread_mutex_init(&mutex,NULL);
	
	// Bucle infinito
	for(;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexi?n\n");
		//sock_conn --> socket para este cliente
		sockets[i] = sock_conn;
		
		//Creamos el thread
		pthread_create (&thread[i], NULL, AtenderCliente, &sockets[i]);
	}
	pthread_mutex_destroy(&mutex);
	exit(0);
}

