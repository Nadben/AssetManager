import React from 'react'
import { StyledCard } from "./Card.styled"
import { WeatherPreview } from '../WeatherPreview';
import { PreviewBox } from './Card.styled';

const Card = ({
  dow,
  preview = false,
  card1 = false,
  d1,
  d2,
  d3,
  d4,
  d5,
  d6,
  d7,
  temp,
  props
}) => {
  return (
<StyledCard>
    <h3>{dow} {(card1) && <> {temp}</>}</h3>
    {(!card1) && <span>{temp}</span>}
  {(preview) && 
    <>
    {console.log(`value of preview = ${preview}`)}
  <PreviewBox>
    <WeatherPreview received_temp={d1} dow="Monday"/>
    <WeatherPreview received_temp={d2} dow="Tuesday"/>
    <WeatherPreview received_temp={d3} dow="Wednesday"/>
    <WeatherPreview received_temp={d4} dow="Thursday"/>
    <WeatherPreview received_temp={d5} dow="Friday"/>
    <WeatherPreview received_temp={d6} dow="Saturday"/>
    <WeatherPreview received_temp={d7} dow="Sunday"/>
  </PreviewBox> 
    </>}
</StyledCard>
  )
}

export default Card;
