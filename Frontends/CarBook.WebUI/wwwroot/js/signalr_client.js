$(document).ready(function () {



    const connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7192/carhub")
        .configureLogging(signalR.LogLevel.Information).build();




    async function start() {

        try {

            await connection.start().then(() => {
                $("#connectionId").html(`connectionId : ${connection.connectionId}`);
                console.log("hub ile bağlantı kuruldu")
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



    $("#btn-like").click(function () {

        const BlogId = document.getElementById("#blog-id").value;
        const UserId = document.getElementById("#user-id").value;
        const UserVote = true;






        

    })


    $("#btn-dislike").click(function () {

        const BlogId = document.getElementById("#blog-id").value;
        const UserId = document.getElementById("#user-id").value;
        const UserVote = false;


        

    })







   


})