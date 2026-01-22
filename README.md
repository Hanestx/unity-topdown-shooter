# \# Mobile Top-Down Shooter (Unity)

# 

# Prototype of a mobile-friendly top-down shooter built with Unity.

# 

# \## 🎮 Features

# \- Rigidbody-based top-down movement

# \- New Input System (keyboard + on-screen joystick)

# \- Auto attack system

# \- Enemy waves with increasing difficulty

# \- Object pooling (bullets \& enemies)

# \- Event-driven health \& damage system

# \- Mobile-safe UI with Safe Area support

# 

# \## 🧱 Architecture

# Project uses a \*\*Component + System\*\* approach:

# 

# \- Components store data and state (Health, Movement, Damage)

# \- Systems handle game logic (Movement, Combat, Waves, Spawning)

# \- ScriptableObjects used for wave configuration

# \- Event-based communication between systems

# 

# \## 🛠 Implemented Patterns

# \- \*\*Singleton\*\* – PoolManager

# \- \*\*Factory\*\* – EnemyFactory

# \- \*\*Observer\*\* – Health \& spawn events

# \- \*\*Object Pooling\*\* – bullets and enemies

# 

# \## 📱 Controls

# \- \*\*PC (Editor):\*\* WASD

# \- \*\*Mobile:\*\* On-Screen Joystick (New Input System)

# 

# \## 📂 Project Structure

Assets/\_Project/

├─ Core

├─ Components

├─ Systems

├─ Input

├─ UI

├─ Data

└─ Pool





\## 🚀 How to Run

1\. Open project in Unity 6.x

2\. Load `Main` scene

3\. Press Play



\## 📌 Notes

This project was created as a portfolio prototype to demonstrate

clean architecture, mobile-ready input, and scalable gameplay systems.



