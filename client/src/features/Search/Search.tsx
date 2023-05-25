import { useAppDispatch, useAppSelector } from "../../context/configureStore";
import { debounce, TextField, Typography, ToggleButton, ToggleButtonGroup } from "@mui/material";
import { fetchAuthors, setAuthorSearch } from "../Account/accountSlice";
import { useCallback, useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Box, Container } from "@mui/material";
import "./Search.css";
import styled from "@emotion/styled";

export default function Search() {
  const {authorSearchParams, authorsLoaded} = useAppSelector(state => state.account);
  const dispatch = useAppDispatch();
  const [searchTerm, setSearchTerm] = useState(authorSearchParams.username);
  const [subjects, setSubjects] = useState<string[]>(() => []);

  const handleFormat = (
    event: React.MouseEvent<HTMLElement>,
    newFormats: string[],
  ) => {
    dispatch(setAuthorSearch({tags: newFormats}));
    setSubjects(newFormats);
  };
  
  useEffect(() => {
    if (!authorsLoaded && authorSearchParams.username !== undefined) {
      if (authorSearchParams.username.length > 0) {
        dispatch(fetchAuthors());
      }
    }
  }, [authorsLoaded, dispatch, authorSearchParams.username])

  const usernameHandler = useCallback(debounce((event: any) => {
    if (event.target.value !== authorSearchParams.username) {
      dispatch(setAuthorSearch({ username: event.target.value }));
      dispatch(setAuthorSearch({ tags: subjects }));
    }
  }, 2000), []);

  const TagButton = styled(ToggleButton)({
    color: 'darkslategray',
    backgroundColor: 'aliceblue',
    padding: 10,
    margin: 5,
    border: 0,
    '&.Mui-selected': {
      backgroundColor: '#28c98e',
      color: 'white'
    },
    '&.MuiToggleButtonGroup-grouped': {
      borderRadius: '7px !important'
    }
  });

  const TagToggleButtonGroup = styled(ToggleButtonGroup)({
    "& > *:not(:last-child)": {
      marginRight: '12px'
    }
  })

  return (
    <>
    <TextField
      sx={{mt: 5, width: '600px'}}
      label="Search Authors"
      variant="outlined"
      fullWidth
      value={searchTerm || ''}
      onChange={(event: any) => {
        setSearchTerm(event.target.value);
        usernameHandler(event);
      }}
      InputProps={{
        style: {
          borderRadius: "10px",
        }
      }}
    />
    <Box
        sx={{
          display: 'flex',
          flexDirection: 'row',
          p: 1,
          m: 1,
          bgcolor: 'background.paper',
          borderRadius: 1,
          justifyContent: 'center'
        }}
      >
        <TagToggleButtonGroup
          value={subjects}
          onChange={handleFormat}
          aria-label="text formatting"
        >
          <TagButton value="informatics">#Informatics</TagButton>
          <TagButton value="math">#Math</TagButton>
          <TagButton value="chemistry">#Chemistry</TagButton>
          <TagButton value="physics">#Physics</TagButton>
          <TagButton value="biology">#Biology</TagButton>
          <TagButton value="geography">#Geography</TagButton>
        </TagToggleButtonGroup>
      </Box>
    { authorsLoaded ? (
      <Container 
        sx={{
          backgroundColor: 'white',
          border: '1px solid #D9D9D9',
          width: '600px',
          minHeight: '20vh',
          borderRadius: '20px',
          justifyContent: 'start',
        }}
      >
        { (typeof(authorSearchParams?.authors) === "undefined") || authorSearchParams?.authors === null ? (
          <Typography>Nothing to display</Typography>
        ) : (
          <ul>
            {authorSearchParams.authors.map(o => <li key={o.id}>
              <Link to={`/${o.authorUsername}`} style={{textDecoration: 'none', color: 'black'}}>{o.authorUsername}</Link>
            </li>)}
          </ul>
        )}
        
      </Container>
    ) : (
        <Typography>Nothing to show</Typography>
    )}
    </>
  );
};