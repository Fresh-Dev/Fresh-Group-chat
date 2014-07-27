Fresh-Group-chat
================
C# Groupchat with PHP Registration and manual HWID Request
--
___
### Project is made of 3 parts###
1. Server 
      - C-Sharp Console Application - Mono Compatible (tested on Ubuntu 12.04)
2. Authentification  Module
      - PHP-Based, SHA256Encrypted passwords, alternative database model (*See bottom*)
        - Future planned WWW-registration possibillity    
3. Chat-Client
      - C-Sharp WinForm Application (*Including huge custom formelements-class*)
        - Login / Registration / HWID Check
        - Smiley-Support
        - Hyperlink-support
        - Desktop-Notifications
        
### General Server Requirements & Prepareations ###
- Webserver with PHP-Support and MCrypt installed & enabled
- Port forwarding for a port of you're choice
- Windows with .net Framework 3.5 or higher or a Mono-Compatible Unix Platform (*Like e.g. Ubuntu 12.04*)

### General Client Requirements ###
- Windows with .net Framework 4.0 or higher
- Internet Access

___
### Setup###
#### Authentification Server ####
- Upload the Auth-Folder's content to web-server (*u may want to place them in a subdirectory, it's ok*)
- Grant CHMOD 0777 on **user/user.txt**
- Open **inc/config.php**
    - ```php 
     /**  
       *  Location of registred user-credentials-file, 
       *    if you want to change path or name, remember, 
       *    to give this file Write-Rights
       */
    var $Userfile = "user/user.txt"; 
    ```
    - ```php 
     /**
	 * Set these to random values
	 */
	var $ky = 'S0M3TH!NG_R4ND0M_H3R3';
	var $iv = '@ND_H3R3_4LS0';
    ```

 - ```php 
    /**
	 * Allowed HWID's add by hand the allowed one returned from first-run of client. 
	 * (CPU-Serial) the two inserted are just for demonstration (Check can be diabled soon)
	 */
	var $machineIDs = array(
		"BAEBFBFF000306C1",
		"FFEBFBFF000206D1"
	);
    ```
##### The authentification server is now ready ! Please note down the URL to index.php  #####

#### Compile Project (*With Visual Studio 2013*) ####

- Open VS-Project File
    - Navigate to **FreshGroupChat [CLIENT]** in Projectexplorer
    - Open: **FreshGroupChat.settings**
		- **server**:*IP/Hostname of the machine where server will be executed later*
        - **port**: *A free port (TCP) the chatserver will use later*
        - **hwid**: can stay empty
        - **username**: *"firstRun" (this will let the registration form open on start)*
        - **authUrl**: Location of the authentification server's index.php
        - **needHwid**: (*Planned Feature  more infos soon*)
        - **needRegistration**: (*Planned Feature  more infos soon*)
    - Press **F6** for compile the whole project 
        - Client-Binary location: **/FreshGroupChat [CLIENT]/bin/Release/**
        - Server (*For Windows machines*): **/FreshGroupChat [SERVER]/bin/Release/** 
            - *If u want to use on UNIX Systems read chapter **Server on UNIX with MONO***
            

#### Run Server on Windows ####
- Open CommandLine
- Navigate to Server's path
- Enter: **<Serverbinary's name> <server's hostname or domain> <port to use>

#### Server on UNIX with MONO #### 
- Make sure apt-get is up 2 date
    - ```sh 
    apt-get update
    apt-get upgrade
   ```
- Now Install Mono-Develop and mono-mcs
    - ```sh 
      apt-get install monodevelop
	  apt-get install mono-mcs
   ```
- Create a new folder (I will do in /root)
    - ```sh 
      mkdir /root/chatserver/
   ```
- Copy Server's Programm.cs file as Server.cs in chatserver/ directory, or vim a new file and copy the content (like I do)
    - ```sh 
      vim Server.cs
   ```
- Compile Server.cs file:
    - ```sh 
      mcs Server.cs
   ```
- Execute Server:
    - ```sh 
      mono Server.exe youre-domain.com 81
   ```
#THATS IT !#
						
							
							
								
USES:
MyTXT PHP Class ( found here: http://techmalt.com/?p=333)