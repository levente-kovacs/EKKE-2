<?php
    // Alapértelmezetten a home értéket menti a page változóba, amennyiben paraméterben nem kap értéket
    $page = isset($_GET['page']) ? $_GET['page'] : 'home';

    // Navigáció a nézetek közt page változó értéke alapján
    switch ($page) {
        case 'home':
            include 'view/home.php';
            break;
        case 'create':
            include 'view/create.php';
            break;
        case 'edit':
            include 'view/edit.php';
            break;
        default:
            include 'view/home.php';
    }
?>
