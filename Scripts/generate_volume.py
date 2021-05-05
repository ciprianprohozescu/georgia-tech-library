import random

random.seed()
f = open("populate_volume.sql", "w")

bookTotal = 100

for i in range(bookTotal):
    volumeNo = random.randint(0, 5)
    if volumeNo == 0:
        continue
    volumeNo = volumeNo - 1

    for j in range(volumeNo):
        library = random.randint(0, 5)

        acquiry_date = ''
        if library != 0:
            day = random.randint(1, 28)
            month = random.randint(1, 12)
            year = random.randint(1990, 2020)
            if day < 10:
                acquiry_date = acquiry_date + '0'
            acquiry_date = acquiry_date + str(day) + '/'
            if month < 10:
                acquiry_date = acquiry_date + '0'
            acquiry_date = acquiry_date + str(month) + '/' + str(year)

        if library != 0:
            f.write(f'insert into Volume (id, book_id, source_library_id, acquiry_date) values ({j + 1}, {i}, {library}, {acquiry_date});\n')
        else:
            f.write(f'insert into Volume (id, book_id) values ({j + 1}, {i});\n')
            
f.close()