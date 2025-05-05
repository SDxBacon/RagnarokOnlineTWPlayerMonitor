package ragnarok

import (
	"encoding/binary"
	"fmt"

	"golang.org/x/text/encoding/traditionalchinese"
	"golang.org/x/text/transform"
)

// DecodeBig5ToUTF8 converts a byte slice encoded in Big5 (Traditional Chinese) to UTF-8 string.
// It takes a byte slice as input and returns the decoded UTF-8 string and any error encountered.
//
// Parameters:
//   - big5Bytes: []byte - The input byte slice encoded in Big5
//
// Returns:
//   - string - The decoded UTF-8 string
//   - error - Any error encountered during decoding, nil if successful
func DecodeBig5ToUTF8(big5Bytes []byte) (string, error) {
	// create a new Big5 decoder
	decoder := traditionalchinese.Big5.NewDecoder()

	// Decode the data using the Big5 decoder
	utf8Bytes, _, err := transform.Bytes(decoder, big5Bytes)
	if err != nil {
		fmt.Println("轉換錯誤:", err)
		return "", err
	}

	return string(utf8Bytes), nil
}

// BytesToInt32 converts a byte slice to an int32 value using little-endian byte order.
// It handles byte slices of various lengths:
//   - Empty slice returns 0
//   - 1 byte returns the byte value as int32
//   - 2 bytes converts to uint16 then to int32
//   - 3 bytes creates a padded 4-byte slice and converts to int32
//   - 4 bytes converts directly to int32
//   - >4 bytes uses only the first 4 bytes
//
// The function always ensures a valid int32 return value regardless of input length.
func BytesToInt32(bytes []byte) int32 {
	switch len(bytes) {
	case 0:
		return 0
	case 1:
		return int32(bytes[0])
	case 2:
		return int32(binary.LittleEndian.Uint16(bytes))
	case 3:
		// 對於 3 字節，我們需要特殊處理
		// 創建一個 4 字節的臨時切片，將原始 3 字節複製進去
		temp := make([]byte, 4)
		copy(temp, bytes)
		return int32(binary.LittleEndian.Uint32(temp))
	case 4:
		return int32(binary.LittleEndian.Uint32(bytes))
	default:
		// 如果超過 4 字節，只取前 4 字節
		return int32(binary.LittleEndian.Uint32(bytes[:4]))
	}
}
