package main

import (
	"content-api/authors"
	"content-api/docs"
	"github.com/gin-gonic/gin"
	swaggerfiles "github.com/swaggo/files"
	ginSwagger "github.com/swaggo/gin-swagger"
	"log"
	"os"
)

// @title Content API
// @version 1.0

func main() {
	router := gin.Default()

	docs.SwaggerInfo.BasePath = "/api/v1"

	v1 := router.Group("/api/v1")
	{
		v1.GET("/authors", authors.GetAuthors)
	}

	router.GET("/swagger/*any", ginSwagger.WrapHandler(swaggerfiles.Handler))

	ginSwagger.WrapHandler(swaggerfiles.Handler,
		ginSwagger.URL("http://localhost:"+os.Getenv("PORT")+"/swagger/doc.json"),
		ginSwagger.DefaultModelsExpandDepth(-1))

	log.Fatal(router.Run(":" + os.Getenv("PORT")))
}
