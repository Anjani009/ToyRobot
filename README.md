# Toy Robot Simulator API
# Overview
The Toy Robot Simulator API simulates a toy robot moving on a square tabletop. The tabletop can have configurable dimensions, specified in appsettings.json. The robot follows a set of commands to move, turn, and report its position and direction.

# Requirements
- .NET 6.0
- Visual Studio or any other .NET IDE
- Postman or any other API testing tool (optional)

# Setup
1. Clone the repository:

```bash
  git clone https://github.com/Anjani009/ToyRobot
  cd ToyRobotAPI
```

2. Install dependencies:

```bash
dotnet restore
```

3. Run the application:
```bash
dotnet run
```
Access Swagger UI:

Open your browser and navigate to https://localhost:5001/swagger or http://localhost:5000/swagger to interact with the API endpoints using Swagger UI.

# API Endpoints
## Place the Robot
- Endpoint: POST /ToyRobot/place
- Description: Places the toy robot on the tabletop at the specified position and direction.
- Request Body
  ```json
  {
  "x": 0,
  "y": 0,
  "direction": "NORTH"
  }
  ```
- Responses
  - 200 OK: Robot placed successfully.
  - 400 Bad Request: Invalid input.

## Move the Robot
- Endpoint: POST /ToyRobot/move
- Description: Moves the toy robot one unit forward in the direction it is currently facing.
- Responses:
  - 200 OK: Robot moved successfully.
  - 400 Bad Request: Robot cannot move out of bounds.

## Turn the Robot Left
- Endpoint: POST /ToyRobot/left
- Description: Rotates the toy robot 90 degrees to the left.
- Responses:
  - 200 OK: Robot turned left successfully.

## Turn the Robot Right
- Endpoint: POST /ToyRobot/right
- Description: Rotates the toy robot 90 degrees to the right.
- Responses:
  - 200 OK: Robot turned right successfully.

## Report the Robot's Position
- Endpoint: GET /ToyRobot/report
- Description: Reports the current position and direction of the toy robot.
- Responses:
  - 200 OK: Returns the robot's current position and direction.

# Test Cases
## Place the Robot and Report:

- Request:
```json
{
  "x": 0,
  "y": 0,
  "direction": "NORTH"
}
```
- Endpoint: POST /ToyRobot/place
- Then: GET /ToyRobot/report
- Expected Output:
```json
 "0,0,NORTH"
```
## Move the Robot and Report:

- First: POST /ToyRobot/place with body:
```json
{
  "x": 0,
  "y": 0,
  "direction": "NORTH"
}
```
- Then: POST /ToyRobot/move
- Finally: GET /ToyRobot/report
- Expected Output:
```json
 "0,1,NORTH"
```
## Turn the Robot Left and Report:

- First: POST /ToyRobot/place with body:
```json
{
  "x": 0,
  "y": 0,
  "direction": "NORTH"
}
```
- Then: POST /ToyRobot/left
- Finally: GET /ToyRobot/report
- Expected Output:
```json
"0,0,WEST"
```
