<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>JSON CRUD-application</title>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Kanit:wght@300&family=Roboto:wght@400;500;700&family=Shippori+Antique&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="assets/font-awesome-4.7.0/css/font-awesome.min.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="css/bg.css">
    <link rel="stylesheet" href="css/style.css">
</head>

<body>
    <div class="background"></div>
    <h1 class="title display-3 m-5 text-white">Y2XWHJ - WebProg II. Beadandó I.</h1>
    <!-- Táblázat az adatok megjelenítésére -->
    <table>
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Email</th>
                <th>Address</th>
                <th>Active</th>
                <th colspan="2">Edit</th>
            </tr>
            <tr class="input__row">
                <th colspan="6">
                    <a href="index.php?page=create">
                        <button class="btn btn-outline-success">
                            <i class="fa fa-user-plus" aria-hidden="true"></i> Add new user
                        </button>
                    </a>
                </th>
            </tr>
        </thead>
        <tbody>
            <?php
                // Adatok lekérése
                $users = get_data($api_url);
                foreach ($users as $user) {
                    // Iconok beállítása aktivitás szerint
                    $isActive = $user['active'] ? "<span style='color: #009879'><i class='fa fa-check-circle' aria-hidden='true'></i></span>" : "<span style='color: rgb(189, 0, 0);'><i class='fa fa-times-circle' aria-hidden='true'></i></span>";
                    // Sor beszúrása a táblázatba a megfelelő adatokkal + módosítás és törlés gombokkal
                    echo "<tr>
                            <td>{$user['id']}</td>
                            <td>{$user['name']}</td>
                            <td>{$user['emailAddress']}</td>
                            <td>{$user['address']}</td>
                            <td>{$isActive}</td>
                            <td>
                                <a href='index.php?page=edit&id={$user['id']}'><button class='edit__button'><i class='fa fa-pencil' aria-hidden='true'></i></button></a>
                                <a href='index.php?page=delete&id={$user['id']}'><button class='delete__button'><i class='fa fa-trash' aria-hidden='true'></i></button></a> 
                            </td>
                        </tr>";
                }
            ?>
        </tbody>
    </table>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>

</html>