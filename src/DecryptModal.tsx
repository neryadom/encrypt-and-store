import React, { useState } from 'react';
import { Modal, Box, TextField, Button, Typography } from '@mui/material';

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  bgcolor: 'background.paper',
  boxShadow: 24,
  p: 4,
};

const DecryptModal = ({ open, handleClose }) => {
  const [encryptedString, setEncryptedString] = useState('');
  const [decryptionKey, setDecryptionKey] = useState('');

  const handleDecrypt = () => {
    // Implement decryption logic here
    console.log('Decryption logic goes here');
    // Close modal after decryption
    handleClose();
  };

  return (
    <Modal
      open={open}
      onClose={handleClose}
      aria-labelledby="decrypt-modal-title"
      aria-describedby="decrypt-modal-description"
    >
      <Box sx={style}>
        <Typography id="decrypt-modal-title" variant="h6" component="h2">
          Decrypt File
        </Typography>
        <TextField
          fullWidth
          label="Encrypted String"
          value={encryptedString}
          onChange={(e) => setEncryptedString(e.target.value)}
          margin="normal"
          variant="outlined"
        />
        <TextField
          fullWidth
          label="Decryption Key"
          value={decryptionKey}
          onChange={(e) => setDecryptionKey(e.target.value)}
          margin="normal"
          variant="outlined"
        />
        <Button onClick={handleDecrypt} variant="contained" sx={{ mt: 2 }}>
          Decrypt
        </Button>
      </Box>
    </Modal>
  );
};

export default DecryptModal;