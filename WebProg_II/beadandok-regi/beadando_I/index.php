<?php
    // Az alkalmazásban használt backend url elmentése globális változóba
    $api_url = 'http://localhost:3000/users';

    // Adatok lekérdezése és értelmezése
    function get_data($url) {
        $json_data = file_get_contents($url);
        return json_decode($json_data, true);
    }

    // function save_data($url, $data, $method) {
    //     $options = [
    //         'http' => [
    //             'header'  => "Content-type: application/json\r\n",
    //             'method'  => $method,
    //             'content' => json_encode($data),
    //         ],
    //     ];
    //     $context = stream_context_create($options);
    //     $result = file_get_contents($url, false, $context);
    //     if ($result === FALSE) {
    //         die('Error');
    //     }
    // }

    function save_data($url, $data, $method) {
        // HTTP kérés opcióinak beállítása
        $options = [
            'http' => [
                // Fejléc beállítása JSON adatokhoz
                'header'  => "Content-type: application/json\r\n",
                // HTTP metódus beállítása (pl. POST, PUT, stb.)
                'method'  => $method,
                // A küldendő adat JSON formátumba konvertálása
                'content' => json_encode($data),
            ],
        ];
        
        // Kontextus létrehozása a megadott opciókkal
        $context = stream_context_create($options);
        
        // Adatok küldése az URL-re a kontextussal
        $result = file_get_contents($url, false, $context);
        
        // Sikertelen http kérés esetén hibaüzenet és a script leállítása
        if ($result === FALSE) {
            die('Error');
        }
    }

    // Alapértelmezetten a home értéket menti a page változóba, amennyiben paraméterben nem kap értéket
    $page = isset($_GET['page']) ? $_GET['page'] : 'home';

    // Navigáció a modulok közt a page változó értéke alapján
    switch ($page) {
        case 'home':
            include 'module/home.php';
            break;
        case 'create':
            include 'module/create.php';
            break;
        case 'edit':
            include 'module/edit.php';
            break;
        case 'delete':
            include 'module/delete.php';
            break;
        default:
            include 'module/home.php';
    }
?>
