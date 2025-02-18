# Q-Puzzle Game

Q-Puzzle Game: A puzzle game where players move colored boxes across a grid to match them with corresponding colored doors. The game features grid-based movement, score tracking, and multiple difficulty levels. Built using C# and .NET, with a focus on UI consistency and exception handling.

## Table of Contents
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Features
- **Grid-based movement**: Players can move boxes in four directions (Up, Down, Left, Right).
- **Matching doors**: Each box is associated with a colored door, and moving a box to its matching door removes it from the grid.
- **Score tracking**: Displays the number of moves and remaining boxes.
- **Multiple difficulty levels**: The game includes prebuilt maze grids of sizes 5x5, 8x8, and 15x15.
- **Custom grid generation**: Players can design their own levels by setting custom grid sizes for rows and columns (from 1 to 15).

## Installation
1. Clone this repository to your local machine:
   ```bash
   git clone https://github.com/AleksandrAinidinov/Q-Puzzle-Game-.git
   ```

## Usage
To run the project:
1. Open the `Q-Puzzle-Game` solution in Visual Studio.
2. Build and start the application by pressing `F5` or clicking "Start" in Visual Studio.
3. Select `Design` to create and save your custom level, or select `Play` to load an existing level.
4. In `Play`, use the arrow keys to move the boxes towards their matching colored doors.

## Contributing
1. Fork the repository.
2. Create a new branch: `git checkout -b feature-name`.
3. Make your changes.
4. Push your branch: `git push origin feature-name`.
5. Create a pull request.

## License
This project is licensed under the [MIT License](LICENSE).
