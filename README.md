# 🐠 Smart Aquarium Controller – SCADA/HMI System
### CSCN72030 — Project III (Group 4)

**Team Members:** Blessed Cheryl Kevin • Tonseobari Edmund-Jaka • Nifemi Olapoju • Britney Pearl Simamu • Chidera Awiaka

## Overview
The Smart Aquarium Controller is a SCADA/HMI-based desktop application built using C# and Windows Forms. It simulates a fully automated aquarium environment by continuously monitoring key water parameters and allowing users to control essential devices that support aquatic life. The system reads simulated sensor data from text files, updates the dashboard every 2 seconds, and provides alerts when readings fall outside safe thresholds.
This project emphasizes Object-Oriented Programming, SOLID design principles, real-time UI updates, and modular architecture. It also integrates manual and automated testing, as well as structured UX evaluation, to ensure the interface is clear, intuitive, and reliable for users with little technical background.

## Key Features

### Real-Time Monitoring (7 Sensors)
- Temperature  
- pH level  
- Oxygen level  
- Water level  
- Light intensity  
- Filter status  
- Food supply level  

All readings refresh automatically on the dashboard.

### Device Control (5 Actuators)
Users can manually toggle:
- Heater  
- LED lights  
- Water pump  
- Air pump  
- Automatic feeder  

Each device has a live ON/OFF indicator and updates instantly on the UI.

### Alert System
The system issues warnings when any sensor reading falls outside safe thresholds. Alerts include:
- Red highlight on affected sensor  
- Pop-up warning messages  
- Auto-reset once readings return to normal  

### Feeding System
- Automated feeding via a scheduled timer  
- Manual “Feed Now” override  
- Feeding events recorded in event log  

### Event Logging
Logs include:
- Alerts  
- Device control actions  
- Feeding events  
- Sensor anomalies  

Users can review the system’s activity history through the dashboard.

## System Architecture

### Main Components
- Sensor classes (TemperatureSensor, PHSensor, OxygenSensor, etc.)  
- Control classes (HeaterControl, LightControl, PumpControl, FeederControl)  
- AlertManager for system alerts  
- MainDashboard (UI)  
- Simulated sensor data text files  

### Data Flow
Sensor File → Sensor Class → Dashboard → User Action → Control Class → Device State → Event Log


## GUI (SCADA/HMI) Design
The dashboard is designed for clarity, simplicity, and ease of use:
- Organized sensor and control layout  
- Color-coded status indicators (Green = Normal, Red = Warning, Gray = OFF)  
- Icons representing each device  
- UX testing conducted to validate usability and readability  

## Testing

### Automated Testing
- Unit tests for sensor parsing and threshold checks  
- Unit tests for device ON/OFF logic  
- Tests for alert triggering  

### Integration Testing
- Dashboard ↔ Sensor synchronization  
- Dashboard ↔ Device control  
- AlertManager across multiple conditions  

### UX Testing
Formal usability testing validated:
- Heater control task  
- Feeding task  
- Alert interpretation  
- Event history navigation  

Feedback improved spacing, layout clarity, and alert visibility.

## Requirements Met
- 7 monitored devices (REQ-SYS-030)  
- 5 controlled devices (REQ-SYS-040)  
- GUI SCADA/HMI interface (REQ-SYS-020)  
- File-based sensor simulation (REQ-SYS-010)  
- SOLID OOP structure (REQ-SYS-003)  
- Automated + manual testing (REQ-SYS-002)  

## Future Improvements
- Cloud-based monitoring  
- Mobile-friendly dashboard  
- Predictive analysis using machine learning  
- More sophisticated water chemistry modeling  

## Acknowledgements
Developed for CSCN72030 – Project III.  
Thanks to our instructor and UX testers for feedback throughout development.
