**Frase del Día**
----
  Retorna JSON con información de la frase del día.

* **URL**

  /api/phrase

* **Método:**
  
  GET

* **Respuesta exitosa::**
  
  * **Código:** 200 <br />
    **Contenido:** `{"phrase":"Causa es de perder lo seguro ir en busca de lo incierto.","author":" Plauto"}`

* **Llamada simple:**
  ```javascript
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
