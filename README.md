<h1>Projekt system rezerwacji seansów.</h1>
Przed uruchomieniem projektu należy wpisać w PackageManagerConsole dwie komendy do zaktualizowania bazy:<br />
<i>update-database -context AppIdentityDbContext</i><br />
<i>update-database -context ApplicationDbContext</i><br />
Domyślnie stworzony użytkownik z uprawnieniami Admina:<br />
Login: Admin<br />
Password: Secret123$<br />
Admin ma dostęp do dodawania,usuwania i edycji seansu, ma dostęp do wszystkich seansów i wszystkich rezerwacji.<br />
Można stworzyć zwyklego użytkownika.<br />
Zwykły uzytkownik ma dostęp do listy aktualnych seansów i swoich seansów. Seans może odwołać i zarezerwować.<br />
