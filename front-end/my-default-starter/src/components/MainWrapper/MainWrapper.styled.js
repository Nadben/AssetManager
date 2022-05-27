import styled from "styled-components/macro";

export const Cards = styled.div`
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  grid-gap: 30px;
  grid-template-areas: 
      "P1 P2 P2 "
      "P3 P3 P3";
`

export const StyledMainWrapper = styled.div`
text-align: center;

h1 {
  font-size: 50px;
  padding: 5px;
  padding-top: 0;
  font-weight: bold;
  text-shadow: 0px 10px 10px black;
}

form {
  margin: 30px;
}

.col1 {
grid-area: P1;
}

.col2 {
grid-area: P2;
}

.col3 {
grid-area: P3;
}

input {
  width: 75%;
  padding: 20px;
  margin-bottom: 10px;
  border-radius: 7.5px;
  font-size: 20px;
  font-weight: bold;
}

button {
  width: 25%;
  padding: 15px;
  border-radius: 10px;
  font-size: 20px;
  font-weight: bold;
  border: none;
  color: white;
  background-color: #04AA6D;
  cursor: pointer;
}

button:hover {
background-color: #038756 ;
}
`

