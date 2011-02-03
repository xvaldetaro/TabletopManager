function foo()
	for i=0,9 do
		spells = io.open("lvl" .. tostring(i) ..".txt", "r")
		aaa = spells:read("*a")
		aaa = string.gsub(aaa, "\n", "")
		aaa = string.gsub(aaa, "Abjur%s", "Abjuration\n")
		aaa = string.gsub(aaa, "Conj%s", "Conjuration\n")
		aaa = string.gsub(aaa, "Div%s", "Divination\n")
		aaa = string.gsub(aaa, "Ench%s", "Enchantment\n")
		aaa = string.gsub(aaa, "Evoc%s", "Evocation\n")
		aaa = string.gsub(aaa, "Illus%s", "Illusion\n")
		aaa = string.gsub(aaa, "Necro%s", "Necromancy\n")
		aaa = string.gsub(aaa, "Trans%s", "Transmutation\n")
		aaa = string.gsub(aaa, "Univ%s", "Universal\n")

		aaa = string.gsub(aaa, "%.", ".\n")
		aaa = string.gsub(aaa, "%.\n(%W)", ".%1")
		aaa = string.gsub(aaa, "\n", "\n!")

		aaa = string.gsub(aaa, "Abjuration", "#Abjuration")
		aaa = string.gsub(aaa, "!Conjuration", "#Conjuration")
		aaa = string.gsub(aaa, "!Divination", "#Divination")
		aaa = string.gsub(aaa, "!Enchantment", "#Enchantment")
		aaa = string.gsub(aaa, "!Evocation", "#Evocation")
		aaa = string.gsub(aaa, "!Illusion", "#Illusion")
		aaa = string.gsub(aaa, "!Necromancy", "#Necromancy")
		aaa = string.gsub(aaa, "!Transmutation", "#Transmutation")
		aaa = string.gsub(aaa, "!Universal", "#Universal")
		aaa = aaa:sub(1,aaa:len()-2)
		aaa = "!" .. aaa
		spells:close()
		parsed = io.open(tostring(i) ..".txt", "w")
		parsed:write(aaa, "\n")
		parsed:flush()
		parsed:close()
	end
end

