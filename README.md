# DevTaskAirports
done by Andrey Bobrov

Not everything is in place, but Architecture and layout of things is there. 

1. There is one unit test for a service, just to show an idea how it is done.
2. Not connected to the database. The repository is present and can connect to any data store implementing the interface. 
3. Worker has an interface to connect to any system you like. 
4. View is not done in the mvc as I didnt have time. Controller/Model/Services are connected together
5. Didn't put things into IOC as it is not finished 

Check the code and you will get the feeling of the architecture and the principles that you were looking for. 
Start with the Controller / AirportsService
