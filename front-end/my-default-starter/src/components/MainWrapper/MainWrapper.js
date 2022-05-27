import axios from 'axios';
import React, { useState, useCallback } from 'react'
import { Card } from '../Card/'
import { WeatherPreview } from '../WeatherPreview';
import { Cards, StyledMainWrapper } from './MainWrapper.styled'


export default function MainWrapper() {
  const [tempData, setTempData] = useState({});
  const [location, setLocation] = useState('');
  const [ShowCard, setShowCard] = useState(false);

  const handleChange = (event) => {
    setLocation(event.target.value);
  }

  const handleSubmit = useCallback(async (event, pLocation) => {
    event.preventDefault();
    const API_KEY = "9bd5881aaf957906ba3e2189e7a96d34"
    const GeoCoding_data = await axios.get(`http://api.openweathermap.org/geo/1.0/direct?q=${pLocation}&limit=5&appid=${API_KEY}`)
    const lon = Math.abs(GeoCoding_data.data[0].lon);
    const lat = Math.abs(GeoCoding_data.data[0].lat);
    //console.log(lon)
    //console.log(lat)
    const { data } = await axios.get(
      `https://api.openweathermap.org/data/2.5/onecall?lat=${lat}&lon=${lon}&appid=9bd5881aaf957906ba3e2189e7a96d34&units=metric`
    )                                                                                     
    setTempData({
      d1: data.daily[0].temp.day,
      d2: data.daily[1].temp.day,
      d3: data.daily[2].temp.day,
      d4: data.daily[3].temp.day,
      d5: data.daily[4].temp.day,
      d6: data.daily[5].temp.day,
      d7: data.daily[6].temp.day
    });
    console.log(`you just wrote : ${location}`)
    setShowCard(true)


  }, [])


  
  return (
    <StyledMainWrapper>
      <h1 id="test">Title</h1>
      <form onSubmit={(e) => {handleSubmit(e, location)}}>
        <input type="text" value={location} onChange={handleChange}></input>
        <button>Click me</button>
      </form>
      <Cards>
        <span className='col1'>
        <Card dow="Today" card1={ShowCard} temp={tempData.d1}/>
        </span>
        <span className='col2'>
        <Card dow="Tuesday" temp={tempData.d2}/>
        </span>
        <span className='col3'>
        <Card dow="Upccoming week" {...tempData} preview={ShowCard}/>
        </span>
      </Cards>
      
    </StyledMainWrapper>
  )
}