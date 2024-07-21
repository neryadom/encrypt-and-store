import { AppBar, Toolbar, Typography } from '@mui/material';
import LockIcon from '@mui/icons-material/Lock'; // Importing a lock icon for the File Encryptor theme

function Header() {
  return (
    <AppBar position="static" className="headerBar">
      <Toolbar>
        <LockIcon sx={{ mr: 2 }} /> {/* Adding an icon before the title */}
        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
          File Encryptor
        </Typography>
      </Toolbar>
    </AppBar>
  );
}

export default Header;