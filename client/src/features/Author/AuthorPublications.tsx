import Card from '@mui/material/Card';
import CardHeader from '@mui/material/CardHeader';
import CardMedia from '@mui/material/CardMedia';
import CardContent from '@mui/material/CardContent';
import CardActions from '@mui/material/CardActions';
import Avatar from '@mui/material/Avatar';
import IconButton from '@mui/material/IconButton';
import { Box, Typography } from '@mui/material';
import { red } from '@mui/material/colors';
import FavoriteIcon from '@mui/icons-material/Favorite';
import ShareIcon from '@mui/icons-material/Share';
import MoreVertIcon from '@mui/icons-material/MoreVert';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import agent from '../../services/agent';
import LoadingComponent from '../../layouts/Loading/LoadingComponent';
import { locationProps } from '../../pages/AuthorPage';
import { Button } from '@mui/material';
import UploadIcon from '@mui/icons-material/Upload';
import ListIcon from '@mui/icons-material/List';

interface subs {
    id: number;
    title: string;
    text: string;
    videoLink: string;
    subscriptionPlanId: string;
    expandedText: boolean;
} 

function AuthorPublications() {
    const location = useLocation();
    const navigate = useNavigate();
    const [publications, setPublications] = useState<subs[]>()
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        location.pathname = location.pathname.substring(1);
        if(location.pathname.includes('post') || location.pathname.includes('about') || location.pathname.includes('membership')) {
            location.pathname = location.pathname.split('/')[0];
        }
        agent.Account.getAuthorByUsername(location.pathname)
            .then(response => probably(response));
        agent.Publication.listByAuthor(location.pathname)
          .then(response => setPublications(response))
          .catch(error => console.log(error))
          .finally(() => setLoading(false));
      }, [location]);

    function probably(isAuthor: boolean) {
        if(isAuthor) {
            return;
        }
        navigate('/NoAccess');
    }

    if(loading) return <LoadingComponent message='Loading subscription plans' />
    
    return (
        <>
            <div style={{position: 'relative'}}>
                {localStorage.getItem('localAuthor') === location.pathname ? (
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
                ) : (
                    <div style={{display: 'none'}}></div>
                )}
                
            </div>
            <div>
                {publications !== undefined && (publications.length > 0) ? (
                    publications.map((pub, i) => {
                        if (localStorage.getItem('localAuthor') === location.pathname) {
                            return (
                                <Card key={i} sx={{ width: '40%' }}  style={{margin: '0 auto 80px auto'}}>
                                    <CardHeader
                                        avatar={
                                        <Avatar sx={{ bgcolor: red[500] }} aria-label="recipe">
                                            R
                                        </Avatar>
                                        }
                                        action={
                                        <IconButton aria-label="settings">
                                            <MoreVertIcon />
                                        </IconButton>
                                        }
                                        title={pub.title}
                                        subheader="September 14, 2016"
                                    />
                                    <Box sx={{ position: 'relative' }}>
                                    <CardMedia
                                        sx={{height: '45vh'}}
                                        component="iframe"
                                        image={pub.videoLink+'?rel=0'}
                                        allowFullScreen
                                    />
                                    </Box>
                                    <CardContent>
                                        <Typography variant="body2" color="text.secondary">
                                        This impressive paella is a perfect party dish and a fun meal to cook
                                        together with your guests. Add 1 cup of frozen peas along with the mussels,
                                        if you like.
                                        </Typography>
                                    </CardContent>
                                    <CardActions disableSpacing>
                                        <IconButton aria-label="add to favorites">
                                        <FavoriteIcon />
                                        </IconButton>
                                        <IconButton aria-label="share">
                                        <ShareIcon />
                                        </IconButton>
                                    </CardActions>
                                </Card>
                            )
                        }
                        return (
                            <Card key={i} sx={{ width: '40%' }}  style={{margin: '0 auto 80px auto'}}>
                            <CardHeader
                                avatar={
                                <Avatar sx={{ bgcolor: red[500] }} aria-label="recipe">
                                    R
                                </Avatar>
                                }
                                action={
                                <IconButton aria-label="settings">
                                    <MoreVertIcon />
                                </IconButton>
                                }
                                title={pub.title}
                                subheader="September 14, 2016"
                            />
                            <Box sx={{ position: 'relative' }}>
                            <CardMedia
                                sx={{height: '45vh', filter: 'blur(8px)', background: 'linear-gradient(90deg, rgba(2,0,36,1) 0%, rgba(144,29,80,1) 100%, rgba(0,212,255,1) 100%)'}}
                                component="iframe"
                            />
                            <Box  sx={{
                                position: 'absolute',
                                bottom: '43%',
                                left: '26%',
                                width: '50%',
                                bgcolor: 'rgba(52, 47, 50, 0.83)',
                                opacity: '0.7',
                                color: 'white',
                                padding: '10px',
                                borderRadius: 4,
                                border: 'none'
                            }}>
                                <Link to="membership" style={{textDecoration: 'none', color: '#dce6df'}}>
                                    <Typography style={{fontSize: '20px'}}>Subscribe</Typography>
                                </Link>
                            </Box>
                            </Box>
                            <CardContent>
                                <Typography variant="body2" color="text.secondary">
                                This impressive paella is a perfect party dish and a fun meal to cook
                                together with your guests. Add 1 cup of frozen peas along with the mussels,
                                if you like.
                                </Typography>
                            </CardContent>
                            <CardActions disableSpacing>
                                <IconButton aria-label="add to favorites">
                                <FavoriteIcon />
                                </IconButton>
                                <IconButton aria-label="share">
                                <ShareIcon />
                                </IconButton>
                            </CardActions>
                        </Card>
                        )
                    }
                        
                    )
                    ) : (
                    <>
                        <img src={require("../../assets/images/robotHead8.png")} style={{width: '100px', height: '100px'}} alt='rob'/>
                        <Typography variant='h4' style={{fontWeight: '500'}}>Oops!</Typography>
                        <Typography style={{fontWeight: '300', fontSize: '15px'}}>There is no posts yet</Typography>
                    </>
                )}
            </div>
        </>
    )
}

export default AuthorPublications