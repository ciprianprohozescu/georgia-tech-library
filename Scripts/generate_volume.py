import random

random.seed()
f = open("populate_volume.sql", "w")

bookTotal = 10000

for i in range(1, bookTotal + 1):
    volumeTotal = random.randint(0, 100)
    if volumeTotal == 0:
        continue
    volumeTotal = random.randint(1, 5)

    for j in range(1, volumeTotal + 1):
        library = random.randint(0, 5)

        acquiryDate = ''
        if library != 0:
            day = random.randint(1, 28)
            month = random.randint(1, 12)
            year = random.randint(1990, 2020)

            acquiryDate = acquiryDate + str(year)
            if month < 10:
                acquiryDate = acquiryDate + '0'
            acquiryDate = acquiryDate + str(month)
            if day < 10:
                acquiryDate = acquiryDate + '0'
            acquiryDate = acquiryDate + str(day)

        if library != 0:
            f.write(f"insert into Volume (id, book_id, source_library_id, acquiry_date) values ({j}, {i}, {library}, '{acquiryDate}');\n")
        else:
            f.write(f'insert into Volume (id, book_id) values ({j}, {i});\n')
            
f.close()