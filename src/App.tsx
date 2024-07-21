import { useState } from 'react';
import './App.css';
import { Container, Button } from '@mui/material';
import Header from './Header';
import FileUpload from './FileUpload';
import DecryptModal from './DecryptModal';

function App() {
  const [modalOpen, setModalOpen] = useState(false);

  const handleOpenModal = () => setModalOpen(true);
  const handleCloseModal = () => setModalOpen(false);

  return (
    <>
     
      <Container maxWidth="md">
        <Header />
        <FileUpload />
        <Button onClick={handleOpenModal} sx={{ mt: 2, bgcolor: 'primary.main', ':hover': { bgcolor: 'primary.dark' }, color: 'white', borderRadius: 2 }}>
  Decrypt File
</Button>
        <DecryptModal open={modalOpen} handleClose={handleCloseModal} />
      </Container>
    </>
  );
}

export default App;