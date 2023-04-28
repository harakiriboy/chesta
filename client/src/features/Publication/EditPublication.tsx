import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Container from '@mui/material/Container';
import { Typography, FormControl, FormLabel, RadioGroup, FormControlLabel, Radio } from '@mui/material';

export default function EditPublication() {
  return (
    <Container sx={{m: '70px 180px 0 180px'}}>
      <Typography variant="h4">Edit Publication</Typography>
      <br/>
      <Box
        component="form"
        sx={{
          '& .MuiTextField-root': { m: 1, width: '50ch' },
          border: '1px solid grey',
          borderRadius: '10px',
        }}
        noValidate
        autoComplete="off"
      >
      <div className='row' style={{display: 'flex'}}>
          <div style={{width: '50%', position: 'relative'}}>
            <img style={{width: '50%', padding: '20px', top: '50%', left: '50%', margin: '0', position: 'absolute', msTransform: 'translate(-50%, -50%)',
            transform: 'translate(-50%, -50%)'}} src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSeLJnzgcw-0NEcuH0joPa1I_-MCWg-yJ_v1FrDzT8&s' alt="kek"/>
          </div>
          <div  style={{width: '50%'}}>
            <div style={{marginBottom: '40px', marginTop: '20px'}}>
              <TextField
                sx={{width: {sm: 200, md: 300}}}
                required
                id="outlined-required"
                label="Title"
                defaultValue="Hello World"
              />
            </div>
            <div  style={{marginBottom: '40px'}}>
            <TextField
                id="outlined-disabled"
                label="Description"
                defaultValue="fbbrueivbeoivnoebvoieb oirnveob oivriornv0"
              />
            </div>
            <div style={{marginBottom: '40px'}}>
              <TextField
                required
                id="filled-required"
                label="Video Link"
                defaultValue="https://youtube.com"
                variant="filled"
              />
            </div>
            <div style={{marginBottom: '40px'}}>
              <FormControl sx={{right: '70px'}}>
                <FormLabel id="demo-row-radio-buttons-group-label" sx={{right: '80px'}}>Subscription plan</FormLabel>
                <RadioGroup
                  row
                  aria-labelledby="demo-row-radio-buttons-group-label"
                  name="row-radio-buttons-group"
                >
                  <FormControlLabel value="female" control={<Radio />} label="Free" />
                  <FormControlLabel value="male" control={<Radio />} label="Buddies" />
                  <FormControlLabel value="other" control={<Radio />} label="Premium" />
                </RadioGroup>
              </FormControl>
            </div>
          </div>
        </div>
    </Box>
    </Container>
  );
}