# GitHubExplorer


ASP.NET MVC application for search repositories and their latest commits....

This project is using :

* C#
* ASP.net
* MVC
* SimpleInjector
* NUnit
* Moq
* nBuilder


------------------------------------------------

Running application in a Windows container ->

Collect all the assets that we need to load into a Docker image in one place. Use the Visual Studio Publish command to create a publish profile for your app.

Publish Project -> Folder Profile ->  bin\Release\Publish -> Click Publish, and Visual Studio will copy all the needed assets to the destination folder.

Build and run the Docker image -> 

1. cmd and navigate to project folder for dockerfile.

2. Use below commands to build and run your Docker image:

	$ docker build -t githubweb .

	$ docker run -d -p 8080:80 --name githubapp githubweb

	Note -> -p argument maps port 8000 on you local machine to port 80 in the container (the form of the port mapping is host:container)

3. Go to localhost:8080 to access your app in a web browser.

	If you are using the Nano Windows Container and have not updated to the Windows Creator Update there is a bug affecting how Windows 10 talks to Containers via “NAT” (Network Address Translation). You must hit the IP of the container directly. You can get the IP address of your container with the following steps:

4. Run docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" githubapp

5. Copy the container ip address and paste into your browser. (For example, 172.xx.xxx.190)

6. To stop your container, issue a docker stop command:

	$ docker stop githubapp

7. To remove the container, issue a docker rm command:

	$ docker rm githubapp
