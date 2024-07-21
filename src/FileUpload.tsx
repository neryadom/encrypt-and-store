import React, { useState } from 'react';
import { Button, Typography, Box, TextField } from '@mui/material';
import CryptoJS from 'crypto-js';
import DecryptModal from './DecryptModal';


function FileUpload() {
  const [fileContent, setFileContent] = useState('');
  const [encrypted, setEncrypted] = useState('');

  const handleEncrypt = (content: string) => {
    const encrypted = CryptoJS.AES.encrypt(content, 'secret key').toString();
    setEncrypted(encrypted);
  };

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
      <Button
        variant="contained"
        component="label"
      >
        Upload File
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
        />
      )}
    </Box>
  );
}

export default FileUpload;