Ubuntu Startup Script
=========

  - Create a new File with our "Servicename" + .conf in /etc/init/ 
  - Paste the content below                                             
 ```shell
author "Kevin Kleinjung"
	description "Startet den Fresg-Group-Chat Server"

	#Set username for the process. Should probably be what you use for logging in
	setuid root

	#This is the install directory. If you installed using a deb package or the NzbDrone Repository you do not need to change this
	env DIR=/root/chatserver

	setgid nogroup
	start on runlevel [2345]
	stop on runlevel [016]

	respawn

	exec mono $DIR/Server.exe youre-server.com 81```

3. Start :) 
 ```bash
	start freshgroupchat
```

	

*That's all :)*
--
