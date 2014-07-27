Fresh-Group-chat
================


C# Groupchat with PHP Registration and manual HWID Request

Project is made of 3 parts:

1. Server (C# - Mono Compatible (Iself run it on Ubuntu 12.04 with Mono))
2. Authentification  Module (PHP)
3. Chat-Client with Login, a few common smileys and hyperlink highlighting and following

Setup:
1. (Client) Open VS-Project File, and navigate to -> FreshGroupChat [CLIENT] 
2. (Client) Open the -> FreshGroupChat.settings file.
		server and port => location of the server used for FreshGroupChat [SERVER] and the selected port (later more)
		hwid: can stay empty
		username:
			firstRun -> Opens the Registration Form, there a request to the authentification part will be send, HWID is known or not.
							If Hwid is unknown, Username & Password Fields stay invisible, until an administrator added the HWID to the WhiteList, 
							if the HWID is known, the user is allowed to register
			After registration the value will be the registered username
		authUrl: Location of the authentification server
		authUrl(Boolean): HWID must be on whitelist or not 
		needRegistration(Boolean): Allow Guests to use it if false
3. (Client) Compile (This part is done)
		
4. (Authentification) Upload the Auth-Folder's content to an PHP-Enabled Web-Server, grant CHMOD 777 on /user/user.txt (Account-Values as txt-database to keep it "movable", 
			passwords will be encrypted with custom salt and key values (set in config.php, where HWID also will be added on whitelist ;))
			
5.1 (Server) WINDOWS: Open commandline and navigate to server's /bin/release folder, run "A51 TeamChat [SERVER].exe" with the the following parameter:
							"A51 TeamChat [SERVER].exe" youre-server.com 81 
								where 81 would be the used TCP Port for the Chat-Application (Must be identical with Client's).
								
5.2 (Server)  UBUNTU (May other unix too):
						
						Make sure apt-get is up 2 date
							>> $ apt-get update
							>> $ apt-get upgrade
						
						Now Install Mono-Develop and mono-mcs
							>> $ apt-get install monodevelop
							>> $ apt-get install mono-mcs
						
						Create a new folder (I will do in /root)
							>> $ mkdir /root/chatserver/
							
						Copy Server's Programm.cs file as Server.cs in chatserver/ directory, or vim a new file and copy the content (like I do)
							>> $ vim Server.cs
								press "i" for insert mode
								-Copy Paste the content- (Putty -> Rightclick to paste)
									ESC to end input mode
									:wq! to save and quit
									
						Compile Server.cs file:
							>> $ mcs Server.cs
							
						If there where no errors (Informations & Warnings are ok, if the is an Compilation succeeded at the end ;) )
						Now u can use mono to run the newly created exe on youre Ubuntu (or other Unix) machine (Parameter same like them for WIN)
							>> $ mono Server.exe youre-domain.com 81
						
						TIP: If u want to run this in background e.g. on a VPS and dont wanne keept putty open, u can do this:
							>> $ apt-get install mono-complete
							>> $ mono-service -d:/youre/path/to/exe Server.exe youre-domain.com 81 & (Dont forget the &-sign ;) )
							
							
						THATS IT !
						
							
							
								
USES:
MyTXT PHP Class ( found here: http://techmalt.com/?p=333)