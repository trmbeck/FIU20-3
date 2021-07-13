# Webservices

- REST: Representational State Transfer
    + Statusfreie (stateless) HTTP Verbindung
    + Beispiel: WebAPI
- Arbitrary Web Service
    + Statusbehaftete Verbindung (TCP)
    + Beispiel: WCF (Windows Communication Foundation), WebSocket

## REST

+ HTTP Operationen/Anfragen werden auf CRUD (Create, Read, Update, Delete) gemappt

+ Aufbau:
    - HTTP-Methode bestimmen
    - URL-Definieren
        - Beispiel: Abfruf eines Kunden mit der Kd.Nr. 5
        - http://servername/Methodenname/parameter
        - http://localhost:8888/Kunde/4
        - Querystring (GET)
        - http://servername/Methodenname?id=XY
        - http://localhost:8888/Kunde?id=5
        - Liste aller Kunden
        - http://localhost:8888/Kunden