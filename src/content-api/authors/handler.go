package authors

import (
	"github.com/gin-gonic/gin"
	"net/http"
)

// GetAuthors @BasePath /api/v1
// @Tags Authors
// @Description Get all authors
// @Schemes
// @Produce json
// @Success 200 {object} Response
// @Router /authors [get]
func GetAuthors(context *gin.Context) {
	context.JSON(http.StatusOK, Response{Items: getAuthors()})
}
