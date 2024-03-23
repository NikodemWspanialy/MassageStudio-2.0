window.onload = () => {

    var currentDate = new Date();

    var minutes = currentDate.getMinutes();
    var roundedMinutes = Math.ceil(minutes / 30) * 30;
    if (roundedMinutes === 60) {
        roundedMinutes = 0;
        currentDate.setHours(currentDate.getHours() + 1);
    }
    currentDate.setMinutes(roundedMinutes);

    // Formatowanie daty i czasu do postaci "RRRR-MM-DD GG:MM"
    var formattedDateTime = currentDate.toISOString().slice(0, 16);

    // Ustawienie wartoœci pola input
    document.getElementById("datetimeInput").value = formattedDateTime;
}
