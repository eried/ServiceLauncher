ServiceLauncher
===============

The main purpose of this application is to provide a way to launch some services on demand, required an specific application. After the application is terminated, the related services are stopped. Useful to deal with applications with lots of Windows services, like VMware Workstation.

Configuration
------

Configure the application you want to launch:<br>
<img src=http://content.screencast.com/users/erwinried/folders/Snagit/media/7adfa403-fee6-4636-81cc-40bd30fc7b32/07.28.2014-16.23.png /><br>

Add the services manually (if they are not specified from the settings):<br>
<img src=http://content.screencast.com/users/erwinried/folders/Snagit/media/b94b854a-ade8-4fee-b0b0-f93786828e6a/07.28.2014-01.22.png /><br>

Set the start mode, fully automatic start and stop is of course the recommended mode. 
<img src=http://content.screencast.com/users/erwinried/folders/Snagit/media/a2f69732-7a5f-4772-93c8-68bac913bf68/07.28.2014-01.22.png /><br>

Now use the ServiceLauncher exe to open your application. Service launcher will start all the required services, and then, your application. When exiting, service launcher will stop all the services.

Related
=======
Download: http://cl.ly/1n3B3X3F4222 (v0.9.1 2014-07-29)<br>
Details: http://ried.cl/servicios-servicios-y-mas-servicios/
