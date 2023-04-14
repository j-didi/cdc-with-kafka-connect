package authors

// Response swagger:Response
type Response struct {
	// All current Authors
	// in: body
	Items []Author `json:"items"`
}
