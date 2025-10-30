# Projet Astronomie VR/AR

 Dans ce projet, j'ai crée une simulation simple du systeme solaire; l'objectif est de montrer le mouvement de la terre et de la lune autour du soleil
voila my view 

 <img width="813" height="518" alt="Capture d'écran 2025-10-25 144438" src="https://github.com/user-attachments/assets/32a3a627-594c-4f5c-b690-a73b10bc8a5e" />

Dans la fenêtre Hierarchy de Unity, on a : 

<img width="508" height="592" alt="Capture d'écran 2025-10-25 144417" src="https://github.com/user-attachments/assets/4e13dfc3-f054-476d-b05f-4a1bab06dafa" />

Pour les assets : 
<img width="734" height="195" alt="Capture d'écran 2025-10-25 144502" src="https://github.com/user-attachments/assets/b38cc8ea-b34f-4111-b9d8-3583d8378a75" />

Le script SolarSystem
Ce script permet de gérer les mouvements des planètes autour du Soleil
<img width="370" height="193" alt="Capture d'écran 2025-10-25 144444" src="https://github.com/user-attachments/assets/7a2d13c2-7295-4709-b594-3a41a3d5ae6f" />

on a : 
a. Déclaration des objets et des vitesses
Dans cette partie du code, je définis les objets utilisés : le Soleil, la Terre et la Lune.
Chaque objet est relié à sa position dans la scène grâce au composant Transform.
Deux vitesses sont aussi indiquées :
- la vitesse de la Terre autour du Soleil,
- la vitesse de la Lune autour du Soleil.
Des variables sont également utilisées pour garder la distance entre les objets, appelée rayon d’orbite.

<img width="902" height="387" alt="Capture d'écran 2025-10-25 144540" src="https://github.com/user-attachments/assets/c58fecd5-42fe-4fc7-a94e-197e1801c521" />

b. Fonction Start()
La fonction Start() s’exécute une seule fois au début.
Elle sert à calculer la distance entre le Soleil et la Terre, puis entre le Soleil et la Lune.
Ces distances sont importantes pour connaître le rayon de chaque orbite avant que les objets commencent à tourner.

c. Fonction Update()
La fonction Update() s’exécute tout le temps pendant le jeu.
Elle fait tourner :
- la Terre autour du Soleil,
- la Lune autour du Soleil.
La fonction RotateAround() permet ce mouvement circulaire.
Time.deltaTime assure que le mouvement reste fluide et régulier.

En résumé :
Start() prépare les distances,
Update() fait bouger les planètes.

<img width="1057" height="561" alt="Capture d'écran 2025-10-25 144549" src="https://github.com/user-attachments/assets/8f8db1cc-7fab-4e3d-bb81-b964b7a9c40e" />

d. Fonction OnDrawGizmos()
Cette fonction ne fait pas bouger les planètes.
Elle sert à dessiner les orbites dans la vue Scene de Unity pour bien voir les trajectoires.
Un cercle bleu montre l’orbite de la Terre.
Un cercle gris montre l’orbite de la Lune.
Ces cercles sont tracés autour du Soleil pour représenter les chemins suivis par les objets.

<img width="953" height="452" alt="Capture d'écran 2025-10-25 144558" src="https://github.com/user-attachments/assets/4378227f-7fc6-4810-99fd-3f517f1448ec" />


e. Fonction DrawOrbit()
Cette fonction sert à dessiner un cercle complet autour du Soleil.
Elle utilise plusieurs petits traits pour former un cercle.
Le centre du cercle est la position du Soleil.
Le rayon correspond à la distance entre le Soleil et la planète.
Une boucle for trace chaque petit segment avec Gizmos.DrawLine().
Cela permet d’afficher une orbite claire et visible dans la scène Unity.

<img width="1259" height="391" alt="Capture d'écran 2025-10-25 144606" src="https://github.com/user-attachments/assets/baa9f759-7756-4d69-93b2-67f2fe701cf0" />

Pour les réglages dans l’inspecteur Unity, on a la partie Orbit Around Sun (Script) affiche tous les éléments du script :
Script : nom du script attaché à l’objet (SolarSystem).
Vitesses d’orbite :
- Earth Orbit Speed = 50 → vitesse de rotation de la Terre,
- Moon Orbit Speed = 50 → vitesse de rotation de la Lune.
Ces valeurs peuvent être changées pour accélérer ou ralentir les mouvements.

<img width="435" height="308" alt="Capture d'écran 2025-10-25 144524" src="https://github.com/user-attachments/assets/eea35062-2a59-4dd8-ab18-b958c52d0496" />



