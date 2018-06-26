# SudokuGA
**Penyelesaian Sudoku dengan Algoritma Genetika**

![Screenshot](https://github.com/luckywind2017/SudokuGA/blob/master/Screenshot/Form.JPG?raw=true "Screenshot")

Ini ada proyek Tugas Akhir saya pada tahun 2011. Program ini bertujuan untuk menyelesaikan puzzle Sudoku menggunakan Algoritma Genetika. File teks berisikan puzzle Sudoku dapat dimasukkan ke dalam program. User dapat memainkan Sudoku atau memaksa program untuk mencari mengisi angka-angka yang kosong dengan benar.

## Format Text File:

Terdiri dari 10 baris
Baris 1 - Tingkat kesulitan soal
Baris 2 s.d. 9 - Soal Sudoku dengan 9 Kolom, angka bantuan diisi 1-9 sementara, angka 0 menunjukkan **Angka Soal** atau kotak kosong yang harus diisi nilainya. Contoh:

>sangat mudah </br>
200803000 </br>
360000079 </br>
010020600 </br>
070350001 </br>
005000300 </br>
600048090 </br>
001070030 </br>
940000068 </br>
000204005 </br>


## Kriteria Tingkat Kesulitan Soal:

| Tingkat Kesulitan | Jumlah Angka Soal |
|-------------------|-------------------|
| Sangat Mudah	    | Lebih dari 50     |
| Mudah	            | 36-49             |
| Sedang	          | 32-35             |
| Sulit	            | 28-31             |
| Sangat Sulit	    | 22-27             |



## Efektivitas Pencarian Solusi:

| Level	| (%) |
|--------|-----|
| Sangat Mudah | 87%
| Mudah	| 80%
| Sedang | 20%
| Sulit	| 13%
| Sangat Sulit | 0%



