package authors

import (
	"database/sql"
	"fmt"
	"log"
	"os"

	_ "github.com/denisenkom/go-mssqldb"
)

func getAuthors() []Author {

	conn, err := openConnection()
	result := readAuthors(err, conn)
	closeConnection(err, conn)

	return result
}

func readAuthors(err error, conn *sql.DB) []Author {

	rows, err := conn.Query("SELECT * FROM Author")
	if err != nil {
		log.Fatal("Error reading records: ", err.Error())
	}

	var result []Author
	for rows.Next() {

		var author Author

		err := rows.Scan(&author.Id, &author.Name)
		if err != nil {
			fmt.Println("Error reading rows: " + err.Error())
		}

		result = append(result, author)
	}

	if result == nil {
		result = []Author{}
	}

	return result
}

func getConnectionString() string {
	connectionString := fmt.Sprintf(
		"server=%s;user id=%s;password=%s;port=%s;database=%s;",
		os.Getenv("DB-HOST"),
		os.Getenv("DB-USER"),
		os.Getenv("DB-PASSWORD"),
		os.Getenv("DB-PORT"),
		os.Getenv("DB-DATABASE"),
	)
	return connectionString
}

func openConnection() (*sql.DB, error) {
	conn, err := sql.Open("mssql", getConnectionString())
	if err != nil {
		log.Fatal("Open connection failed:", err.Error())
	}
	return conn, err
}

func closeConnection(err error, conn *sql.DB) {
	err = conn.Close()
	if err != nil {
		log.Fatal("Close connection failed:", err.Error())
	}
}
