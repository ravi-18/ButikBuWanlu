# ButikBuWanlu
Api untuk butik bu wanlu

## Test Runing
- pertama update database dengan menggunakan perintah 
- jika menggunakan visual studio bisa mengetikan```Update-Database``` dalam "package-manager console" yang ada didalam menu ```Tools -> NuGet Package Manager -> Package Manager Console```
- jika menggunakan visual studio code bisa menggunakan perintah ```dotnet ef database update``` pada console, untuk memunculkannya bisa menekan kombinasi ```ctrl + ` ```
- dalam console ketikan ```docker-compose up``` untuk membuat docker image
- lalu jalankan docker dengan memilih execute docker jika dalam visual studio lalu tekan F5, jika menggunakan visual studio code ```docker-compose build```

*Jika runing dengan docker terdapat error maka bisa melakukan runing tanpa docker dengan memilih execute "ButikAPI" dan sesuaikan untuk connectionString yang ada pada appsetting.json
   

## Insert data
Untuk insert data tidak dapat dilakukan sekali execute query karena data dalam satu kali execute query di sql server maksimum 1000 data. Sehingga untuk execute bisa di split 1000 data.
caranya :
- buka file sql yang akan di execute.
- tekan ```ctrl + G``` lalu masukan 1000 
- kemudian block query sampai ke atas sehingga ter block kurang lebih 1000 data yang akan di insert.
- kemudian execute.

untuk split kedua di ambil dari row 1000 - 2000 dan seterusnya. begitu juga dengan insert data yang lain.


