import { Button } from '@mui/material';
import './AuthorMain.css';
import UploadIcon from '@mui/icons-material/Upload';
import ListIcon from '@mui/icons-material/List';
import { Link } from 'react-router-dom';

function AuthorMain() {
  return (
    <>
        <div className="row">
            <div className="column" style={{position: 'relative'}}>
                {/* <p style={{position: 'absolute', bottom: 0, left: '50px'}}></p> */}
            </div>
            <div className="column">
                <div className="row">
                <div style={{width: '80px', height: '80px', borderRadius: '50%',
                    backgroundColor: 'red', margin: '0 auto'}}>
                </div>
                </div>
                <div className="row">
                    <p style={{fontSize: '16px', fontWeight: 'bold', margin: '5px auto'}}>harakiriboy</p>
                </div>
                <div className="row">
                    <p style={{fontSize: '15px', margin: '5px auto'}}>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Optio dolor eos, voluptatum, perspiciatis unde quibusdam.</p>
                </div>
            </div>
            <div className="column" style={{position: 'relative'}}>
                {/* <p  style={{position: 'absolute', bottom: 0, right: '50px'}}>byeeee</p> */}
                <div style={{position: 'absolute', bottom: 0, right: '50px'}}>
                    <Button variant='outlined' color='primary' sx={{mr: 1, borderRadius: '10px'}}>
                        <Link style={{textDecoration: 'none', color: '#3f50b5'}} to="/posts/create">Create</Link>
                    </Button>
                    <Button variant='outlined' color='info' sx={{mr: 1, borderRadius: '10px'}}>
                        <UploadIcon/>
                    </Button>
                    <Button variant='outlined' color='error' sx={{mr: 1, borderRadius: '10px'}}>
                        <Link style={{height: '24px'}} to="/posts/edit">
                            <ListIcon/>
                        </Link>
                    </Button>
                </div>
            </div>
        </div>
    </>
  )
}

export default AuthorMain