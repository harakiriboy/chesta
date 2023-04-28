import { AppBar, Container, Toolbar, Typography, Box, IconButton, Menu, MenuItem, Button, Tooltip, Avatar } from '@mui/material';
import React from 'react';
import MenuIcon from '@mui/icons-material/Menu';
import { Link } from "react-router-dom";
import { signOut } from '../../features/Account/accountSlice';
import { useAppDispatch, useAppSelector } from '../../context/configureStore';

const pages = ['Home', 'Search'];

function Navbar() {
  const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(null);
  const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(null);

  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  };
  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const dispatch = useAppDispatch(); 
  const {user} = useAppSelector(state => state.account);

  return (
    <>
    <AppBar position="static" style={{backgroundColor: '#28c98e'}}>
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <Typography variant="h6"
            noWrap
            component="a"
            href="/"
            sx={{
              mr: 2,
              display: { xs: 'none', md: 'flex' },
              fontFamily: 'monospace',
              fontWeight: 700,
              letterSpacing: '.3rem',
              color: 'inherit',
              textDecoration: 'none',
            }} >
            <img src={require("../../assets/images/CHESTA.png")} alt="hi" style={{width: '130px', height: 'auto', margin: 'auto 0'}}/>
          </Typography>

          <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}>
            <IconButton
              size="large"
              aria-label="account of current user"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleOpenNavMenu}
              color="inherit"
            >
              <MenuIcon />
            </IconButton>
            <Menu
              id="menu-appbar"
              anchorEl={anchorElNav}
              anchorOrigin={{
                vertical: 'bottom',
                horizontal: 'left',
              }}
              keepMounted
              transformOrigin={{
                vertical: 'top',
                horizontal: 'left',
              }}
              open={Boolean(anchorElNav)}
              onClose={handleCloseNavMenu}
              sx={{
                display: { xs: 'block', md: 'none' },
              }}
            >
              {pages.map((page) => (
                <MenuItem key={page} onClick={handleCloseNavMenu}>
                  <Link to="/Search">
                    <Typography textAlign="center">{page}</Typography>
                  </Link>
                </MenuItem>
              ))}
            </Menu>
          </Box>
          {/* <AdbIcon sx={{ display: { xs: 'flex', md: 'none' }, mr: 1 }} /> */}
          <Typography
            variant="h5"
            noWrap
            component="a"
            href=""
            sx={{
              mr: 2,
              display: { xs: 'flex', md: 'none' },
              flexGrow: 1,
              fontFamily: 'monospace',
              fontWeight: 700,
              letterSpacing: '.3rem',
              color: 'inherit',
              textDecoration: 'none',
            }}
          >
            <img src={require("../../assets/images/CHESTA.png")} alt="hi" style={{width: '130px', height: 'auto', margin: 'auto 0'}}/>
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
            {pages.map((page) => (
              <Button
                key={page}
                onClick={handleCloseNavMenu}
                sx={{ my: 2, color: 'white', display: 'block' }}
              >
                <Link to={`/${page}`} style={{textDecoration: 'none', color: 'white'}}>
                  {page}
                </Link>
              </Button>
            ))}
          </Box>
          {user ? (
            <Box sx={{ flexGrow: 0 }}>
            <Tooltip title="Open settings">
              <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                <Avatar alt="Remy Sharp" src="/static/images/avatar/2.jpg" />
              </IconButton>
            </Tooltip>
            <Menu
              sx={{ mt: '45px' }}
              id="menu-appbar"
              anchorEl={anchorElUser}
              anchorOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              keepMounted
              transformOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              open={Boolean(anchorElUser)}
              onClose={handleCloseUserMenu}
            >
              <MenuItem key={'Settings'} onClick={handleCloseUserMenu}>
                  <Link to='/Settings' style={{textDecoration: 'none', color: 'black'}}>{'Settings'}</Link>
              </MenuItem>
              {user.role === "author" && 
                <div>
                  <MenuItem key={'Members'} onClick={handleCloseUserMenu}>
                    <Link to='/Members' style={{ textDecoration: 'none', color: 'black' }}>{'Members'}</Link>
                  </MenuItem>
                  <MenuItem key={'Payouts'} onClick={handleCloseUserMenu}>
                      <Link to='/Payouts' style={{ textDecoration: 'none', color: 'black' }}>{'Payouts'}</Link>
                  </MenuItem>
                  <MenuItem key={'Insights'} onClick={handleCloseUserMenu}>
                      <Link to='/Insights' style={{ textDecoration: 'none', color: 'black' }}>{'Insights'}</Link>
                  </MenuItem>
                </div>
              }
              <MenuItem key={'Checkout'} onClick={handleCloseUserMenu}>
                  <Link to='/Checkout' style={{textDecoration: 'none', color: 'black'}}>{'Checkout'}</Link>
              </MenuItem>
              <MenuItem key={'Author'} onClick={handleCloseUserMenu}>
                  <Link to={`${user.email}`} style={{textDecoration: 'none', color: 'black'}}>{'Author'}</Link>
              </MenuItem>
              <MenuItem key={'Logout'} onClick={() => dispatch(signOut())}>
                  <Link to='/' style={{textDecoration: 'none', color: 'black'}}>{'Logout'}</Link>
              </MenuItem>
            </Menu>
          </Box>
          ) : (
          <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' }, justifyContent: 'end' }}>
            <Button
              key='Login'
              sx={{ my: 2, color: 'white', display: 'block' }}
            >
              <Link to={'/Login'} style={{textDecoration: 'none', color: 'white'}}>
                Login
              </Link>
            </Button>
            <Button
              key='Register'
              sx={{ my: 2, color: 'white', display: 'block' }}
            >
              <Link to={'/Register'} style={{textDecoration: 'none', color: 'white'}}>
                Register
              </Link>
            </Button>  
          </Box>
          )}
        </Toolbar>
      </Container>
    </AppBar>
    </>
  )
}

export default Navbar