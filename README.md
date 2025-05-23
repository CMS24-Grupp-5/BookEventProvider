#BOOKEVENTPROVIDER

Author: KrystylGP

Azure URL: https://bookeventprovider.azurewebsites.net

BookEventProvider är en microservice som hanterar bokning av evenemang. Den används tillsammans med EventViewProvider (som listar events) och EventProvider (som tillhandahåller eventdata).
Den tar emot bokningar från frontend, kopplar användare till event, lagrar dessa i en databas och låter användaren visa eller avboka bokningar (My Events).

API funktioner (REST): 
SKAPA BOKNING
* URL: /api/booking
* Metod: POST
* Skapar en bokning (kräver userId, eventId).

HÄMTA BOKNINGAR 
* URL: /api/booking/by-user?userId=...
* Metod: GET
* Hämtar bokningar för inloggad användare.
  
AVBOKA  
* URL: /api/booking/{bookingId}
* Metod: DELETE
* Tar bort en specifik bokning.

Funktion i frontend:
* Boka-knapp visas vid varje event i eventlistan.
* My Events-sidan visar alla bokade events med titel, plats och datum för när eventet bokades.
* Avboka-knapp låter användaren ta bort en bokning.

DEMOBILDER

<img width="947" alt="Frontend - Booking" src="https://github.com/user-attachments/assets/13ba3e52-69c5-4874-b6cb-6e2ec262ed3b" />

<img width="946" alt="Frontend - My Events" src="https://github.com/user-attachments/assets/348adcb9-6e6e-47cc-b347-8170f51b2075" />

<img width="948" alt="Frontend - Cancel booking" src="https://github.com/user-attachments/assets/80586612-ae3a-4bae-8ff8-5b44211fdc36" />

