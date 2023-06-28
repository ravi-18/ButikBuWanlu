# ButikBuWanlu
Api untuk butik bu wanlu

[Tautan ke Revisi](#revisi)


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
   tenMostBuyersPerMonth {
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
  totalSalesPerYear {
    branchName
    totalSales
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

### Branch mutation dan query

Untuk menambahkan branch baru.
```
mutation createBranch($input:BranchRegisterInput!)
{
  createBranch(input: $input){
    id
    name
  }
}

Variable
{
   "input": {
     "name": "Jakarta"
    }
}
```

Untuk edit branch.
```
mutation modifyBranch($input:BranchModifyInput!)
{
  modifyBranch(input: $input){
    id
    name
  }
}

Variable
{
   "input": {
     "id": "0f3bd201-f79c-4eff-a9a1-28c54c30d83f";
     "name": "Jakarta"
    }
}
```

Untuk delete branch.
```
mutation deleteBranch($id : UUID!){
  deleteBranch(id: $id)
  {
     value
     message
  }
}

Variable
{
	"id":"8c44722e-5b63-461f-b508-5523d3ba1aca"
}
```

Untuk get list dan get by filter.
```
query branch {
  branch (
     where:{id:{eq:"8c44722e-5b63-461f-b508-5523d3ba1aca"}}
  )
  {
    nodes {
      id
      name
    }
  }
}
```

### Customer mutation dan query

Untuk membuat customer baru.
```
mutation createCustomer($input : CustomerRegisterInput!)
createCustomer(input: $input)
{
    id
    name
    email
    registrationDate
    branchId
    branch {
      id
      name
    }
}

Variable:
{
  "input": {
    "name": "Name",
    "email": "name@mail.com",
    "branchId": "0f3bd201-f79c-4eff-a9a1-28c54c30d83f",
    "registrationDate": "27/06/2023"
  }
}
```

Untuk edit customer.
```
mutation modifyCustomer($input: CustomerModifyInput!)
{
  id
  name
  email
  registrationDate
  branchId
  branch {
    id
    name
  }
}

Variable:
{
  "input": {
    "id": "f779838e-a94e-46a4-8d85-df7eeaa6b195",
    "name": "Name",
    "email": "name@mail.com",
    "branchId": "0f3bd201-f79c-4eff-a9a1-28c54c30d83f",
    "registrationDate": "27/06/2023"
  }
}
```

Untuk delete Customer.
```
mutation deleteCustomer($id: UUID!)
{
  deleteCustomer(id: $id)
  {
    value
    message
  }
}

Variable:
{
  "id":"f779838e-a94e-46a4-8d85-df7eeaa6b195"
}
```

Untuk get customers dan get by id customer.
```
query customer {
  customer {
    nodes {
      id
      name
      email
      registrationDate
      branchId
      branch {
        id
        name
      }
    }
  }
}
```

## Product mutation dan query

Untuk membuat product.
```
mutations createProduct($input: ProductRegisterInput)
{
  createProduct(input: $input)
  {
    id
    name
    price
  }
}

Variable
{
  "input": {
    "name": "Kaos Oblong",
     "price": 25000
  }
}
```

Untuk edit product.
```
mutation modifyProduct($input: ProductModifyInput!)
{
  modifyProduct(input: $input){
    id
    name
    price
  } 
}

Variable
{
  "input": {
     "id": "f30fc891-ef1b-42d5-a419-352d8347d4ee",
     "name": "Kaos Oblong",
     "price": 25000
  }
}
```

Untuk Delete Product.
```
mutation deleteProduct{
  deleteProduct(id:"f30fc891-ef1b-42d5-a419-352d8347d4ee"){
    value
    message
  }
}
```

Untuk get Product dan get by filter product.
```
query product {
  product {
    nodes{
      id
      name
      price
    }
  }
}
```

### Transaction mutation dan query.

Untuk create Transaction.
```
mutation createTransaction($input: TransactionRegisterInput!) {
  createTransaction(input: $input) {
    id
    quantity
    transactionDate
    customer {
      id
      name
      email
      registrationDate
      branch {
        id
        name
      }
    }
    product {
      id
      name
      price
    }
  }
}

Variable:
{
   "input": {
    "quantity": 3,
    "transactionDate": "27/06/2023",
    "customerId": "c0080411-8e79-44a2-a51d-c1b96ce0f245",
    "productId": "f30fc891-ef1b-42d5-a419-352d8347d4ee"
   }
}
```

Untuk Edit Transaction.
```
mutation createTransaction($input: TransactionRegisterInput!) {
  createTransaction(input: $input) {
    id
    quantity
    transactionDate
    customer {
      id
      name
      email
      registrationDate
      branch {
        id
        name
      }
    }
    product {
      id
      name
      price
    }
  }
}

Variable:
{ 
  "input": {
    "id": "40d65823-1e0c-455c-ab4a-78c7eff3f848",
    "quantity": 3,
    "transactionDate": "27/06/2023",
    "customerId": "c0080411-8e79-44a2-a51d-c1b96ce0f245",
    "productId": "f30fc891-ef1b-42d5-a419-352d8347d4ee"
   }
}
```

Untuk delete Transaction.
```
mutation deleteTransaction{
  deleteTransaction(id: "40d65823-1e0c-455c-ab4a-78c7eff3f848")
  {
    value
    message
  }
}
```

Untuk get Transaction dan get by filter Transaction.
```
query transaction{
  transaction{
    nodes{
      id
      quantity
      transactionDate
      customer {
        id
        name
        email
        registrationDate
        branch {
          id
          name
        }
      }
      product {
        id
        name
        price
      }
    }
  }
}
```

## Revisi
1. totalSalesPerYear : Error terjadi karena limitasi dari type data integer, 
    solusinya adalah dengna mengconversi hasil perhitungan dan menyimpannya dalam type data long.

2. fiveSalesIncreasePerMonth : Error terjadi karena join Transaction dengan Transaction dilakukan langsung dengan 
    dbcontext. Solusinya membuat transaction menjadi list terlebih dahulu yang telah difilter sehingga tidak perlu mengambil semua data transaction, kemudian dijoin dengan linq. Dan satu lagi yang membuat error yaitu join antara list dengan dbcontext, karena tidak didukung secara langsung oleh LINQ. Solusinya mengambil dulu data menjadi list dengan filter dan kemudian baru di join antara list dengan list.

3. "/p:UseAppHost=false" : Dalam DockerFile terdapat Opsi ini, bertujuan untuk menginstruksikan alat build 
    untuk tidak menggunakan file apphost (host aplikasi) yang dihasilkan selama proses build. File apphost adalah file eksekusi yang dibuat saat proyek .NET Core dibangun dengan opsi "ProduceSingleFile" diaktifkan. File ini memungkinkan Anda menjalankan aplikasi .NET Core tanpa perlu menggunakan dotnet run atau dotnet <nama-file>.dll. Namun, dalam konteks kontainer Docker, file apphost tidak diperlukan karena umumnya aplikasi .NET Core dijalankan melalui perintah dotnet <nama-file>.dll. Oleh karena itu, dengan menggunakan opsi /p:UseAppHost=false, dapat menghindari pembuatan file apphost yang tidak diperlukan dalam kontainer Docker, sehingga mengurangi ukuran kontainer dan mempercepat proses build.