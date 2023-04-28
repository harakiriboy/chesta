import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Container from '@mui/material/Container';
import { Typography, FormControl, FormLabel, RadioGroup, FormControlLabel, Radio } from '@mui/material';

export default function CreateMemership() {
  return (
    <Container sx={{m: '70px 180px 50px 180px'}}>
      <Typography variant="h4">New Subscription Plan</Typography>
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
            <div style={{marginBottom: '40px', marginTop: '40px'}}>
              <TextField
                sx={{width: {sm: 200, md: 300}}}
                required
                id="outlined-required"
                label="Name"
                placeholder="Example"
              />
            </div>
            <div  style={{marginBottom: '40px'}}>
            <TextField
                id="outlined-disabled"
                label="Description"
                multiline
                placeholder="Thi is the desciption for my subscription plan"
              />
            </div>
            <div  style={{marginBottom: '40px'}}>
            <TextField
                id="outlined-disabled"
                label="Price"
                defaultValue={1000}
              />
            </div>
            <div style={{marginBottom: '40px'}}>
              <FormControl sx={{right: '120px'}}>
                <FormLabel id="demo-row-radio-buttons-group-label">Recurrent charge schedule</FormLabel>
                <RadioGroup
                  row
                  aria-labelledby="demo-row-radio-buttons-group-label"
                  name="row-radio-buttons-group"
                >
                  <FormControlLabel value="month" control={<Radio />} label="Montlhy" />
                  <FormControlLabel value="annual" control={<Radio />} label="Annual" />
                </RadioGroup>
              </FormControl>
            </div>
          </div>
        </div>
    </Box>
    </Container>
  );
}