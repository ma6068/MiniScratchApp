# MiniScratchApp

### How to start this application?
- Just clone the project and open it in Visual Studio 2022. Then start the MiniScratchApp project.

### Elements in our application:

- Inbound address for the server, which should follow the format {protocol}://{domain}. Example: http://localhost. For easier differentiation, it is colored in blue.
- Inbound port for the server, which should specify only the port. Example: 8080. For easier differentiation, it is colored in blue.
- Outbound address for the client, which should follow the format {protocol}://{domain}. Example: http://localhost.
- Outbound port for the client, which should specify only the port. Example: 8080.
- Dropdown (used by the client) that indicates the type of request being sent (GET, POST, PUT, DELETE).
- Field for sending the message (body), which should be in JSON format. This is sent only if using the POST or PUT method. Example:
```shell script
{
"Name" : "Martin",
"Surname" : "Arsovski"
}
```
- Field for sending the header, which should follow the key-value format. Example:
```shell script
Cache-Control : no-cache
Accept : application/json
```
- Field for incoming requests, used to receive incoming requests with a timestamp.
- Start/Stop buttons, used to control when the services are started or stopped.
- A panel that, indicates which command will be executed based on the elements contained within it.

### How the application works when the Start button is pressed:
- If the Panel does not contain any elements, an error message will appear: "Please enter all the necessary elements to start the server or to send the request." The same message will appear if any required field is missing.
- The required fields for starting the server are InboundAddress and InboundPort. If both are placed in the Panel, the server will start listening on the specified URL. A validation is included to ensure that both fields are correctly filled.
- The required fields for starting the client are OutboundAddress and OutboundPort. If the dropdown that specifies the request method is set to POST or PUT, the Body field is also required. Headers are optional. After a successful request is sent, the request data will be recorded in the Incoming requests field.

### How the application works when the Stop button is pressed:
- If the stop button is pressed, both the server and the client are stopped.

### Where are the values and positions of the elements stored?
- We save them in a JSON file called "controlPositions.json," which is created automatically (if it doesn't already exist). Upon restarting the application, we read all the values and positions of the elements from it. Example:
```shell script
{
  "TxtBoxInboundAddressPosition": "54, 303",
  "TxtBoxInboundPortPosition": "230, 303",
  "TxtBoxOutboundAddressPosition": "64, 64",
  "TxtBoxOutboundPortPosition": "61, 125",
  "TextBoxBodyPosition": "821, 64",
  "TextBoxHeadersPosition": "897, 212",
  "TextBoxIncomingRequestsPosition": "230, 45",
  "TxtBoxInboundAddressText": "http://localhost",
  "TxtBoxInboundPortText": "3000",
  "TxtBoxOutboundAddressText": "http://localhost",
  "TxtBoxOutboundPortText": "3000",
  "TextBoxBodyText": "{\r\n\"Name\" : \"Martin\",\r\n\"Surname\" : \"Arsovski\"\r\n}",
  "TextBoxHeadersText": "Cache-Control : no-cache\r\nAccept : application/json\n",
  "TextBoxIncomingRequestsText": "2024-10-12 10:14:22: POST request received at http://localhost:3000/\r\n2024-10-12 10:15:26: POST request received at http://localhost:3000/\r\n2024-10-12 10:18:23: POST request received at http://localhost:3000/\r\n2024-10-12 10:21:27: POST request received at http://localhost:3000/\r\n2024-10-12 10:29:54: GET request received at http://localhost:3000/\r\n2024-10-12 10:30:03: PUT request received at http://localhost:3000/\r\n2024-10-12 10:30:11: DELETE request received at http://localhost:3000/\r\n",
  "ComboBoxSelectedIndex": 2
}
```
