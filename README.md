ServiceLauncher
===============

Starts and stops services required for a program before and after launching the program itself. Useful to deal with applications with lots of required Windows services, like VMware Workstation.

How to
------

Configure the application you want to launch:<br>
<img src=http://f.cl.ly/items/2U1q082z1Z2o2f2A2r1I/Image%202014-07-28%20at%201.14.26%20am.png /><br>

Add the services manually (if they are not specified from the settings):<br>
<img src=http://f.cl.ly/items/1t1v2i1u1F0G0M2j330N/Image%202014-07-28%20at%201.15.33%20am.png /><br>

Set the start mode, fully automatic start and stop is of course the recommended mode. 
<img src=http://f.cl.ly/items/0J0t3e0r1X3j1N1C2w1d/Image%202014-07-28%20at%201.16.02%20am.png /><br>

Now use the ServiceLauncher exe to open your application. Service launcher will start all the required services, and then, your application. When exiting, service launcher will stop all the services.

Related
=======
Download: http://cl.ly/0m1G2z3y2111 (v0.9 2014-07-28)<br>
Details: http://ried.cl/servicios-servicios-y-mas-servicios/
