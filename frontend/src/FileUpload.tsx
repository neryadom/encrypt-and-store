import React, { useState, useCallback } from 'react';
import { Button, Typography, Box, TextField } from '@mui/material';
import CryptoJS from 'crypto-js';
import { useDropzone } from 'react-dropzone';

function FileUpload() {
  const [encrypted, setEncrypted] = useState('');

  const handleEncrypt = (content: string) => {
    const encrypted = CryptoJS.AES.encrypt(content, 'secret key').toString();
    setEncrypted(encrypted);
  };

  const onDrop = useCallback((acceptedFiles) => {
    const file = acceptedFiles[0];
    const reader = new FileReader();
    reader.onload = (e) => {
      const content = e.target?.result;
      if (content) {
        handleEncrypt(content.toString());
      }
    };
    reader.readAsDataURL(file);
  }, []);

  const { getRootProps, getInputProps, isDragActive } = useDropzone({ onDrop });

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        const content = e.target?.result;
        if (content) {
          handleEncrypt(content.toString());
        }
      };
      reader.readAsDataURL(file);
    }
  };

  return (
    <Box mt={4}>
      <Typography variant="h5" gutterBottom>
        Upload and Encrypt File
      </Typography>
      <Box {...getRootProps()} sx={{ border: '2px dashed #000', padding: '20px', textAlign: 'center' }}>
        <input {...getInputProps()} onChange={handleFileChange} />
        {
          isDragActive ?
            <p>Drop the files here ...</p> :
            <p>Drag and drop some files here, or click to select files</p>
        }
      </Box>
      <Button
        variant="contained"
        component="label"
        sx={{ mt: 2 }}
      >
        Select File
        <input
          type="file"
          hidden
          onChange={handleFileChange}
        />
      </Button>
      {encrypted && (
        <TextField
          fullWidth
          multiline
          rows={4}
          margin="normal"
          label="Encrypted Content"
          value={encrypted}
          variant="outlined"
          sx={{ mt: 2 }}
        />
      )}
    </Box>
  );
}

export default FileUpload;