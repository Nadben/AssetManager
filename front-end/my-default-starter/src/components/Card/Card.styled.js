import styled from "styled-components"

/** Indentation helps readibility */
export const StyledCard = styled.div`
border-radius: 15px;
user-select: none; 
display: flex;
flex-direction: column;
height: auto; // 300px
background-color: #282828;
//height: 400px;
box-shadow: 0 0 10px black;
min-height: 100px;

h3 {
 margin: 0;
 padding: 20px;
 padding-left: 30px;
 font-size: 25px;
 text-align: left;
}
`
export const PreviewBox = styled.div`
display: flex;
flex-direction: row;
align-content: center;
justify-content: space-evenly;
span {
}

`
