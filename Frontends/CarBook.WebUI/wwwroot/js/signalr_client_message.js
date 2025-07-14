$(document).ready(function () {


    const connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7192/carhub")
        .configureLogging(signalR.LogLevel.Information)
        .build();



    const currentUserIdForMessage = parseInt(document.getElementById("currentUserId").value);
    const otherUserIdForMessage = parseInt(document.getElementById("otherUserId").value);



    async function start() {

        try {

            await connection.start().then(() => {
                $("#connectionId").html(`connectionId : ${connection.connectionId}`);
                console.log("hub ile bağlantı kuruldu Message Hub")
            });

        }
        catch (err) {
            console.error("hub ile bağlantı kurulamadı", err);
            setTimeout(() => start(), 3000);
        }

    }

    connection.onclose(async () => {
        await start(); // bağlantı yeniden kurulana kadar bekliyorum aslında ben burda
    });

    start();

    connection.on("getUpdatedMessages", (messages) => {

        console.log("mesajlar");
        console.log(messages);



    });




    $("#btn-send-message").click(function () {



        if (currentUserIdForMessage == 0) {
            window.location.href = "/Login/Index";
            return;
        }

        const messageContent = document.getElementById("replyMessageContent").value;


        connection.invoke("AddAndUpdateMessage", currentUserIdForMessage, otherUserIdForMessage, messageContent).catch(function (err) {
            console.error(err.toString());
        });


    })





})