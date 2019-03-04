**Frase del Día**
----
  Retorna JSON con información de la frase del día.

* **URL**

  /api/phrase

* **Method:**
  
  GET

* **Success Response:**
  
  <_What should the status code be on success and is there any returned data? This is useful when people need to to know what their callbacks should expect!_>

  * **Código:** 200 <br />
    **Contenido:** `{"phrase":"Causa es de perder lo seguro ir en busca de lo incierto.","author":" Plauto"}`

* **Sample Call:**
  ```
  var xhr = new XMLHttpRequest();
  xhr.open('GET', 'https://frasedeldia.azurewebsites.net/api/phrase');
  xhr.onload = function() {
      if (xhr.status === 200) {
          console.log(xhr.responseText);
      }
      else {
          console.log('Error');
      }
  };
  xhr.send();
  ```

* **Notes:**

  <_This is where all uncertainties, commentary, discussion etc. can go. I recommend timestamping and identifying oneself when leaving comments here._> 
