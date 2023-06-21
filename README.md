# ButikBuWanlu
Api untuk butik bu wanlu

## Test Runing
- pertama update database dengan menggunakan perintah 
- jika menggunakan visual studio bisa mengetikan```Update-Database``` dalam "package-manager console" yang ada didalam menu ```Tools -> NuGet Package Manager -> Package Manager Console```
- jika menggunakan visual studio code bisa menggunakan perintah ```dotnet ef database update``` pada console, untuk memunculkannya bisa menekan kombinasi ```ctrl + ` ```
- dalam console ketikan ```docker-compose up``` untuk membuat docker image
- lalu jalankan docker dengan memilih execute docker jika dalam visual studio lalu tekan F5, jika menggunakan visual studio code ```docker-compose build```

### note:
* Jika runing dengan docker terdapat error maka bisa melakukan runing tanpa docker dengan memilih execute "ButikAPI" dan sesuaikan untuk connectionString yang ada pada appsetting.json
* Untuk CRUD data terdapat pada endpoint swagger. jika api telah run bisa switch ke endpoint swagger.   

## Insert data
Untuk insert data tidak dapat dilakukan sekali execute query karena data dalam satu kali execute query di sql server maksimum 1000 data. Sehingga untuk execute bisa di split 1000 data.
caranya :
- buka file sql yang akan di execute.
- tekan ```ctrl + G``` lalu masukan 1000 
- kemudian block query sampai ke atas sehingga ter block kurang lebih 1000 data yang akan di insert.
- kemudian execute.

untuk split kedua di ambil dari row 1000 - 2000 dan seterusnya. begitu juga dengan insert data yang lain.


## Query GraphQL

1. Untuk menampilkan data pakaian dengan harga paling tinggi dan paling
murah.
```
query{
 productHighestPrice{
  id
  name
  price
 }
}
```
```
query {
  productLowestPrice {
    id
    name
    price
  }
}
```
2. Untuk menampilkan data pelanggan yang pertama kali mendaftar
(pelanggan terlama) dan pelanggan yang terakhir kali mendaftar (pelanggan
terbaru) berdasarkan cabang.
```
query {
  newCustomer {
	id
	name
	email
	registrationDate
	branchId
  }
}
```
```
query {
  oldCustomer {
	id
	name
	email
	registrationDate
	branchId
  }
}
```

3. Untuk menampilkan 10 data pakaian yang paling banyak dibeli dalam 1 bulan
di setiap cabang (berdasarkan quantity).
```
query {
  tenBestSellingProductsPerMonth{
    id
    name
    price 
  }
}
```
4. Untuk menampilkan 10 data pelanggan yang paling besar belanjanya dalam
1 bulan di setiap cabang (berdasarkan akumulasi total belanja).
```
query {
   tenMostBuyersPerMonth() {
	  branchName
	  month
	  customerName
	  totalSpending
   }
}
```
5. Untuk menampilkan data nominal penjualan setiap cabang dalam 1 tahun.
```
query {
   tenBestSeller{
    id
    name
    price
   }
}
```
6. Untuk menampilkan 5 data pakaian yang mengalami peningkatan tertinggi
penjualan dalam bulan ini dibandingkan bulan sebelumnya. Dengan cara
membandingkan quantity yg terjual bulan ini dengan quantity yang terjual
bulan sebelumnya.
```
query {
   fiveSalesIncreasePerMonth {
      id
	  name
	  price
	  quantityIncrease
   }
}
```

