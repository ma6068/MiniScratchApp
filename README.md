# MiniScratchApp

### Elements in our application:

- Inbound address for the server, which should follow the format {protocol}://{domain}. Example: http://localhost. For easier differentiation, it is colored in blue.
- Inbound port for the server, which should specify only the port. Example: 8080. For easier differentiation, it is colored in blue.
- Outbound address for the client, which should follow the format {protocol}://{domain}. Example: http://localhost.
- Outbound port for the client, which should specify only the port. Example: 8080.
- Dropdown (used by the client) that indicates the type of request being sent (GET, POST, PUT, DELETE).
- Field for sending the message (body), which should be in JSON format. This is sent only if using the POST or PUT method.
- Field for sending the header, which should follow the key-value format. Example:
```shell script
Cache-Control: no-cache
Content-Type: application/json
```
- Field for incoming requests, used to receive incoming requests with a timestamp.
- Start/Stop buttons, used to control when the services are started or stopped.
- A panel that, indicates which command will be executed based on the elements contained within it.

### How the application works when the Start button is pressed:
- If the Panel does not contain any elements, an error message will appear: "Please enter all the necessary elements to start the server or to send the request." The same message will appear if any required field is missing.
- The required fields for starting the server are InboundAddress and InboundPort. If both are placed in the Panel, the server will start listening on the specified URL. A validation is included to ensure that both fields are correctly filled.
- The required fields for starting the client are OutboundAddress and OutboundPort. If the dropdown that specifies the request method is set to POST or PUT, the Body field is also required. Headers are optional. After a successful request is sent, the request data will be recorded in the Incoming requests field.
