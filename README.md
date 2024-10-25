<p align="center">
    <img src="https://github.com/user-attachments/assets/420e8260-a19c-4e91-a091-7b8aa4c59bd0" alt="logo" width="400">
</p>

<h1 align="center">Kurei's Mighty and Incredible Blindtest Project</h1>

<p align="justify"><em>Kurei's Mighty and Incredible Blindtest Project</em> (might change the name in the future, it's way too long) is a C# project that allows you to test your music knowledge in a fun and interactive way. In each round, a sample of a song is played, and you must choose the correct answer from four options.</p>

<h2 align="center">Table of Contents</h2>

1. [Project Overview](#project-overview)
2. [Features](#features)
3. [Technologies Used](#technologies-used)
4. [Installation and Usage](#installation-and-usage)
5. [Potential Bugs](#potential-bugs)

<h2 align="center">Project Overview</h2>

<p align="justify">The goal of <strong>Kurei's Mighty and Incredible Blindtest Project</strong> is to provide an immersive experience in the world of music while testing your knowledge. Each question will introduce you to a variety of songs, ranging from classics to recent hits. This project is designed for all music enthusiasts who want to have fun while learning.</p>

<h2 align="center">Features</h2>

- **Interactive Tests**: Play a musical blindtest and try to guess the titles and artists.
- **Result Evaluation**: Get a score at the end of each test to measure your performance.
- **User-Friendly Interface**: Modern and clean design for smooth navigation.
- **Frequent Updates**: Regularly add new songs and features.

<h2 align="center">Installation and Usage</h2>

<h3>1. Clone the repository</h3>

```bash
git clone https://github.com/leotrnn/kureiblindtest.git
```

<h2 align="center">Potential Bugs</h2>

<h3>You can't play a song and this error "Song Unaviable : 'please sign in'" shows ?</h3>
<p align="justify">In your Visual Studio : Tools -> Manager NugGet package -> Console</p>
<p align="center">
    <img src="https://github.com/user-attachments/assets/ee6ecae1-116a-439d-8f8c-ac6fd7d7e997" alt="logo" width="800">
</p>
<p align="justify">Just uninstall and reinstall YoutubeExplode</p>

```bash
Uninstall-Package YoutubeExplode
Ininstall-Package YoutubeExplode
```

<h3>The music sample appears empty when you try to play it ?</h3>

<p align="Justify">Many solutions :</p>

<h4>The sample chose a part of the song where there is no music</h4>
<p>Can't do much about it, remove the song from the database or keep it until the sample choose a good part</p>

<h4>The sample is too short</h4>
<p>That means that the song is also too short, here's the configurations of the samples length</p>
<p align="center">
    <table>
    <tr>
        <th>Difficulty</th>
        <th>Length</th>
    </tr>
    <tr>
        <td>Easy</td>
        <td>5s</td>
    </tr>
     <tr>
        <td>Medium</td>
        <td>3s</td>
    </tr>
     <tr>
        <td>Hard</td>
        <td>1s</td>
    </tr>
</table>
</p>


