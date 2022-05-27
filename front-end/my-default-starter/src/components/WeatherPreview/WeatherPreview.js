import React from 'react'
import { StyledWeatherPreview } from './WeatherPreview.styled'


export default function WeatherPreview(props) {
  return (
    <StyledWeatherPreview>
      <h2> {props.dow} </h2>
      <div> {props.received_temp}</div>
    </StyledWeatherPreview>
  )
}
