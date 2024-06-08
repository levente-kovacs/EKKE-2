<?php
$api_url = 'http://localhost:3000/users';

function get_data($url) {
    $json_data = file_get_contents($url);
    return json_decode($json_data, true);
}

function save_data($url, $data, $method) {
    $options = [
        'http' => [
            'header'  => "Content-type: application/json\r\n",
            'method'  => $method,
            'content' => json_encode($data),
        ],
    ];
    $context = stream_context_create($options);
    $result = file_get_contents($url, false, $context);
    if ($result === FALSE) {
        die('Error');
    }
}

$page = isset($_GET['page']) ? $_GET['page'] : 'home';

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
